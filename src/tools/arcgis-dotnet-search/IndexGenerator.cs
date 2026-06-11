using System.Diagnostics;
using System.Text.Json;
using System.Text.RegularExpressions;

internal static partial class IndexGenerator
{
    private const string SamplesRepoUrl = "https://github.com/Esri/arcgis-runtime-samples-dotnet.git";
    private const string ToolkitRepoUrl = "https://github.com/Esri/arcgis-maps-sdk-dotnet-toolkit.git";
    private const string DemosRepoUrl = "https://github.com/Esri/arcgis-runtime-demos-dotnet.git";

    public static int Run(string[] args)
    {
        string? output = null;
        string? samplesPath = null;
        string? toolkitPath = null;
        string? demosPath = null;
        string? workDir = null;
        bool keep = false;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--output" when i + 1 < args.Length:
                    output = args[++i];
                    break;
                case "--samples" when i + 1 < args.Length:
                    samplesPath = args[++i];
                    break;
                case "--toolkit" when i + 1 < args.Length:
                    toolkitPath = args[++i];
                    break;
                case "--demos" when i + 1 < args.Length:
                    demosPath = args[++i];
                    break;
                case "--workdir" when i + 1 < args.Length:
                    workDir = args[++i];
                    break;
                case "--keep":
                    keep = true;
                    break;
                case "--help":
                case "-h":
                    PrintUsage();
                    return 0;
                default:
                    Console.Error.WriteLine($"Unknown update-index option: {args[i]}");
                    PrintUsage();
                    return 1;
            }
        }

        output = Path.GetFullPath(output ?? ResolveDefaultOutputPath());
        var tempRoot = Path.GetFullPath(workDir ?? Path.Combine(Path.GetTempPath(), "arcgis-dotnet-search-" + Guid.NewGuid().ToString("N")));
        var ownsWorkDir = workDir == null;

        try
        {
            Directory.CreateDirectory(tempRoot);

            samplesPath = ResolveRepo(samplesPath, tempRoot, "arcgis-runtime-samples-dotnet", SamplesRepoUrl);
            toolkitPath = ResolveRepo(toolkitPath, tempRoot, "arcgis-maps-sdk-dotnet-toolkit", ToolkitRepoUrl);
            demosPath = ResolveRepo(demosPath, tempRoot, "arcgis-runtime-demos-dotnet", DemosRepoUrl);

            var entries = new List<SampleEntry>();
            entries.AddRange(ReadRuntimeSamples(samplesPath));
            entries.AddRange(ReadToolkitSamples(toolkitPath));
            entries.AddRange(ReadDemos(demosPath));

            var ordered = entries
                .OrderBy(e => e.Source, StringComparer.OrdinalIgnoreCase)
                .ThenBy(e => e.Platform, StringComparer.OrdinalIgnoreCase)
                .ThenBy(e => e.Category, StringComparer.OrdinalIgnoreCase)
                .ThenBy(e => e.Title, StringComparer.OrdinalIgnoreCase)
                .ToArray();

            var outputDir = Path.GetDirectoryName(output);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            File.WriteAllText(output, JsonSerializer.Serialize(ordered, JsonContext.Default.SampleEntryArray));
            Console.WriteLine($"Wrote {ordered.Length} entries to {output}");
            return 0;
        }
        finally
        {
            if (!keep && ownsWorkDir && Directory.Exists(tempRoot))
            {
                try { Directory.Delete(tempRoot, recursive: true); }
                catch (Exception ex) { Console.Error.WriteLine($"Warning: failed to delete temp folder '{tempRoot}': {ex.Message}"); }
            }
        }
    }

    private static void PrintUsage()
    {
        Console.WriteLine("arcgis-dotnet-search update-index [options]");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --output path    Output samples.json path. Defaults to this tool's Data\\samples.json when discoverable.");
        Console.WriteLine("  --samples path   Use an existing arcgis-runtime-samples-dotnet clone instead of cloning.");
        Console.WriteLine("  --toolkit path   Use an existing arcgis-maps-sdk-dotnet-toolkit clone instead of cloning.");
        Console.WriteLine("  --demos path     Use an existing arcgis-runtime-demos-dotnet clone instead of cloning.");
        Console.WriteLine("  --workdir path   Folder for temporary clones. Defaults to a temp folder.");
        Console.WriteLine("  --keep           Keep temporary clones after generation.");
    }

    private static string ResolveRepo(string? existingPath, string tempRoot, string folderName, string repoUrl)
    {
        if (!string.IsNullOrWhiteSpace(existingPath))
        {
            var full = Path.GetFullPath(existingPath);
            if (!Directory.Exists(full))
            {
                throw new DirectoryNotFoundException($"Repository path does not exist: {full}");
            }

            return full;
        }

        var target = Path.Combine(tempRoot, folderName);
        if (Directory.Exists(target))
        {
            return target;
        }

        RunGit($"clone --depth 1 {Quote(repoUrl)} {Quote(target)}");
        return target;
    }

    private static void RunGit(string arguments)
    {
        var psi = new ProcessStartInfo
        {
            FileName = "git",
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        using var process = Process.Start(psi) ?? throw new InvalidOperationException("Failed to start git.");
        var stdout = process.StandardOutput.ReadToEnd();
        var stderr = process.StandardError.ReadToEnd();
        process.WaitForExit();
        if (process.ExitCode != 0)
        {
            throw new InvalidOperationException($"git {arguments} failed with exit code {process.ExitCode}\n{stdout}\n{stderr}");
        }
    }

    private static IEnumerable<SampleEntry> ReadRuntimeSamples(string repoRoot)
    {
        var roots = new[]
        {
            (Platform: "wpf", Root: Path.Combine(repoRoot, "src", "WPF", "WPF.Viewer", "Samples")),
            (Platform: "winui", Root: Path.Combine(repoRoot, "src", "WinUI", "ArcGIS.WinUI.Viewer", "Samples")),
            (Platform: "maui", Root: Path.Combine(repoRoot, "src", "MAUI", "Maui.Samples", "Samples")),
        };

        foreach (var (platform, root) in roots)
        {
            if (!Directory.Exists(root))
            {
                continue;
            }

            foreach (var metadataPath in Directory.EnumerateFiles(root, "readme.metadata.json", SearchOption.AllDirectories))
            {
                if (IsBuildOutput(metadataPath))
                {
                    continue;
                }

                using var doc = JsonDocument.Parse(File.ReadAllText(metadataPath));
                var meta = doc.RootElement;
                if (meta.TryGetProperty("ignore", out var ignore) && ignore.ValueKind == JsonValueKind.True)
                {
                    continue;
                }

                var folder = Path.GetDirectoryName(metadataPath)!;
                var formalName = GetString(meta, "formal_name") ?? Path.GetFileName(folder);
                var snippets = GetStringArray(meta, "snippets");

                yield return new SampleEntry
                {
                    Id = $"runtime-{platform}-{Slug(formalName)}",
                    Title = GetString(meta, "title") ?? SplitCamel(formalName),
                    Category = GetString(meta, "category") ?? "",
                    Description = GetString(meta, "description") ?? "",
                    Source = "runtime",
                    Platform = platform,
                    Repository = "Esri/arcgis-runtime-samples-dotnet",
                    Path = Relative(repoRoot, folder),
                    Keywords = GetStringArray(meta, "keywords"),
                    RelevantApis = GetStringArray(meta, "relevant_apis"),
                    Files = snippets,
                    Xaml = ReadSnippet(folder, snippets, ".xaml"),
                    CSharp = ReadSnippet(folder, snippets, ".cs"),
                    Notes = []
                };
            }
        }
    }

    private static IEnumerable<SampleEntry> ReadToolkitSamples(string repoRoot)
    {
        var roots = new[]
        {
            (Platform: "wpf", Root: Path.Combine(repoRoot, "src", "Samples", "Toolkit.SampleApp.WPF")),
            (Platform: "winui", Root: Path.Combine(repoRoot, "src", "Samples", "Toolkit.SampleApp.WinUI")),
            (Platform: "maui", Root: Path.Combine(repoRoot, "src", "Samples", "Toolkit.SampleApp.Maui")),
        };

        foreach (var (platform, root) in roots)
        {
            if (!Directory.Exists(root))
            {
                continue;
            }

            foreach (var codePath in Directory.EnumerateFiles(root, "*.xaml.cs", SearchOption.AllDirectories))
            {
                if (IsBuildOutput(codePath))
                {
                    continue;
                }

                var code = File.ReadAllText(codePath);
                var attribute = SampleInfoRegex().Match(code);
                if (!attribute.Success)
                {
                    continue;
                }

                var properties = ParseNamedProperties(attribute.Groups["args"].Value);
                var className = Path.GetFileNameWithoutExtension(Path.GetFileNameWithoutExtension(codePath));
                var xamlPath = codePath[..^".cs".Length];
                var category = properties.GetValueOrDefault("Category") ?? SplitCamel(Path.GetFileName(Path.GetDirectoryName(codePath)) ?? "");
                var title = properties.GetValueOrDefault("DisplayName") ?? SplitCamel(RemoveSuffix(className, "Sample"));
                var description = properties.GetValueOrDefault("Description") ?? title;
                var apiKeyRequired = properties.TryGetValue("ApiKeyRequired", out var apiKey) && apiKey.Equals("true", StringComparison.OrdinalIgnoreCase);

                yield return new SampleEntry
                {
                    Id = $"toolkit-{platform}-{Slug(category + "-" + className)}",
                    Title = title,
                    Category = category,
                    Description = description,
                    Source = "toolkit",
                    Platform = platform,
                    Repository = "Esri/arcgis-maps-sdk-dotnet-toolkit",
                    Path = Relative(repoRoot, Path.GetDirectoryName(codePath)!),
                    Keywords = apiKeyRequired ? [category, title, "toolkit", "api key"] : [category, title, "toolkit"],
                    RelevantApis = [category],
                    Files = File.Exists(xamlPath) ? [Path.GetFileName(xamlPath), Path.GetFileName(codePath)] : [Path.GetFileName(codePath)],
                    Xaml = File.Exists(xamlPath) ? Truncate(File.ReadAllText(xamlPath), 6000) : null,
                    CSharp = Truncate(code, 6000),
                    Notes = apiKeyRequired ? ["Requires an ArcGIS API key or equivalent authentication in the sample app."] : []
                };
            }
        }
    }

    private static IEnumerable<SampleEntry> ReadDemos(string repoRoot)
    {
        var src = Path.Combine(repoRoot, "src");
        if (!Directory.Exists(src))
        {
            yield break;
        }

        foreach (var demoDir in Directory.EnumerateDirectories(src))
        {
            var readmePath = Path.Combine(demoDir, "README.md");
            if (!File.Exists(readmePath))
            {
                continue;
            }

            var markdown = File.ReadAllText(readmePath);
            var title = GetMarkdownTitle(markdown, Path.GetFileName(demoDir));
            var description = GetFirstParagraph(markdown);
            var xamlPath = FindFirstMatchingFile(demoDir, "*.xaml", file => DemoFileRegex().IsMatch(Path.GetFileName(file)));
            var codePath = FindFirstMatchingFile(demoDir, "*.cs", file => DemoFileRegex().IsMatch(Path.GetFileName(file)));

            yield return new SampleEntry
            {
                Id = $"demo-{Slug(Path.GetFileName(demoDir))}",
                Title = title,
                Category = "Demo app",
                Description = description,
                Source = "demo",
                Platform = DetectDemoPlatform(demoDir),
                Repository = "Esri/arcgis-runtime-demos-dotnet",
                Path = Relative(repoRoot, demoDir),
                Keywords = [SplitCamel(Path.GetFileName(demoDir)), "demo"],
                RelevantApis = [],
                Files = new[] { "README.md" }
                    .Concat(xamlPath != null ? [Path.GetFileName(xamlPath)] : Array.Empty<string>())
                    .Concat(codePath != null ? [Path.GetFileName(codePath)] : Array.Empty<string>())
                    .ToArray(),
                Xaml = xamlPath != null ? Truncate(File.ReadAllText(xamlPath), 6000) : null,
                CSharp = codePath != null ? Truncate(File.ReadAllText(codePath), 6000) : null,
                Notes = ["Demo apps show full application structure; adapt patterns rather than copying wholesale."]
            };
        }
    }

    private static Dictionary<string, string> ParseNamedProperties(string args)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (Match match in StringPropertyRegex().Matches(args))
        {
            result[match.Groups["name"].Value] = match.Groups["value"].Value;
        }

        foreach (Match match in BoolPropertyRegex().Matches(args))
        {
            result[match.Groups["name"].Value] = match.Groups["value"].Value;
        }

        return result;
    }

    private static string? ReadSnippet(string folder, string[] preferredFiles, string extension)
    {
        foreach (var file in preferredFiles)
        {
            if (!file.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var path = Path.Combine(folder, file);
            if (File.Exists(path))
            {
                return Truncate(File.ReadAllText(path), 6000);
            }
        }

        var fallback = Directory.EnumerateFiles(folder, "*" + extension, SearchOption.TopDirectoryOnly).FirstOrDefault();
        return fallback != null ? Truncate(File.ReadAllText(fallback), 6000) : null;
    }

    private static string? FindFirstMatchingFile(string root, string pattern, Func<string, bool> predicate) =>
        Directory.EnumerateFiles(root, pattern, SearchOption.AllDirectories)
            .Where(file => !IsBuildOutput(file))
            .FirstOrDefault(predicate);

    private static string DetectDemoPlatform(string demoDir)
    {
        foreach (var project in Directory.EnumerateFiles(demoDir, "*.csproj", SearchOption.AllDirectories).Where(file => !IsBuildOutput(file)))
        {
            var text = File.ReadAllText(project);
            if (text.Contains("Microsoft.NET.Sdk.Maui", StringComparison.OrdinalIgnoreCase))
            {
                return "maui";
            }

            if (text.Contains("WinUI", StringComparison.OrdinalIgnoreCase) || text.Contains("Microsoft.WindowsAppSDK", StringComparison.OrdinalIgnoreCase))
            {
                return "winui";
            }
        }

        return "wpf";
    }

    private static string GetMarkdownTitle(string markdown, string fallback)
    {
        var lines = markdown.Replace("\r\n", "\n").Split('\n');
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i].Trim();
            if (line.StartsWith("# ", StringComparison.Ordinal))
            {
                return line[2..].Trim();
            }

            if (i + 1 < lines.Length && lines[i + 1].Trim().All(c => c == '=') && line.Length > 0)
            {
                return line;
            }
        }

        return SplitCamel(fallback);
    }

    private static string GetFirstParagraph(string markdown)
    {
        var lines = new List<string>();
        foreach (var line in markdown.Replace("\r\n", "\n").Split('\n'))
        {
            var trimmed = line.Trim();
            if (trimmed.Length == 0 || trimmed.StartsWith('#') || trimmed.StartsWith("<img", StringComparison.OrdinalIgnoreCase)
                || trimmed.All(c => c == '=') || trimmed.StartsWith("Required version:", StringComparison.OrdinalIgnoreCase))
            {
                if (lines.Count > 0)
                {
                    break;
                }

                continue;
            }

            lines.Add(trimmed);
            if (lines.Count >= 4)
            {
                break;
            }
        }

        var paragraph = WhitespaceRegex().Replace(string.Join(" ", lines), " ").Trim();
        return paragraph.Length > 280 ? paragraph[..277] + "..." : paragraph;
    }

    private static string[] GetStringArray(JsonElement element, string propertyName)
    {
        if (!element.TryGetProperty(propertyName, out var property) || property.ValueKind != JsonValueKind.Array)
        {
            return [];
        }

        return property.EnumerateArray()
            .Select(item => item.GetString())
            .Where(value => !string.IsNullOrWhiteSpace(value))
            .Select(value => value!)
            .ToArray();
    }

    private static string? GetString(JsonElement element, string propertyName) =>
        element.TryGetProperty(propertyName, out var property) ? property.GetString() : null;

    private static string ResolveDefaultOutputPath()
    {
        foreach (var start in new[] { Directory.GetCurrentDirectory(), AppContext.BaseDirectory })
        {
            var found = FindUp(start, Path.Combine("src", "tools", "arcgis-dotnet-search", "Data", "samples.json"))
                ?? FindUp(start, Path.Combine("Data", "samples.json"));
            if (found != null)
            {
                return found;
            }
        }

        return Path.Combine(Directory.GetCurrentDirectory(), "Data", "samples.json");
    }

    private static string? FindUp(string start, string relativePath)
    {
        var current = new DirectoryInfo(start);
        while (current != null)
        {
            var candidate = Path.Combine(current.FullName, relativePath);
            if (File.Exists(candidate))
            {
                return candidate;
            }

            current = current.Parent;
        }

        return null;
    }

    private static string Slug(string text)
    {
        var slug = SlugNoiseRegex().Replace(text.ToLowerInvariant(), "-").Trim('-');
        return string.IsNullOrWhiteSpace(slug) ? "sample" : slug;
    }

    private static string SplitCamel(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return text;
        }

        var chars = new List<char>(text.Length + 8);
        for (var i = 0; i < text.Length; i++)
        {
            if (i > 0 && char.IsUpper(text[i]) && char.IsLower(text[i - 1]))
            {
                chars.Add(' ');
            }

            chars.Add(text[i]);
        }

        return new string(chars.ToArray()).Replace("Arc GIS", "ArcGIS", StringComparison.Ordinal).Replace("Geo View", "GeoView", StringComparison.Ordinal).Trim();
    }

    private static string Truncate(string text, int max)
    {
        var normalized = text.Replace("\r\n", "\n").Trim();
        return normalized.Length <= max ? normalized : normalized[..max] + "\n// ... truncated ...";
    }

    private static string Relative(string root, string path) =>
        Path.GetRelativePath(root, path).Replace('/', '\\');

    private static bool IsBuildOutput(string path) =>
        path.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase)
        || path.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase);

    private static string Quote(string value) => "\"" + value.Replace("\"", "\\\"") + "\"";

    private static string RemoveSuffix(string value, string suffix) =>
        value.EndsWith(suffix, StringComparison.Ordinal) ? value[..^suffix.Length] : value;

    [GeneratedRegex(@"\[SampleInfo(?:Attribute)?\((?<args>[\s\S]*?)\)\]")]
    private static partial Regex SampleInfoRegex();

    [GeneratedRegex(@"(?<name>\w+)\s*=\s*""(?<value>[^""]*)""")]
    private static partial Regex StringPropertyRegex();

    [GeneratedRegex(@"(?<name>\w+)\s*=\s*(?<value>true|false)", RegexOptions.IgnoreCase)]
    private static partial Regex BoolPropertyRegex();

    [GeneratedRegex(@"MainPage|Map|Scene|View|Page|Service|Location|Route", RegexOptions.IgnoreCase)]
    private static partial Regex DemoFileRegex();

    [GeneratedRegex(@"[^a-z0-9]+")]
    private static partial Regex SlugNoiseRegex();

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhitespaceRegex();
}
