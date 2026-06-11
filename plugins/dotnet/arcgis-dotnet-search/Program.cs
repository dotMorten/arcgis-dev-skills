internal static class Program
{
    private static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            return PrintUsage();
        }

        var command = args[0].ToLowerInvariant();
        if (command == "update-index")
        {
            return IndexGenerator.Run(args.Skip(1).ToArray());
        }

        var engine = new SearchEngine(DataLoader.LoadSamples());
        return command switch
        {
            "search" => RunSearch(engine, args.Skip(1).ToArray()),
            "get" => RunGet(engine, args.Skip(1).ToArray()),
            "list" => RunList(engine, args.Skip(1).ToArray()),
            "debug" => RunDebug(engine, args.Skip(1).ToArray()),
            _ => PrintUsage()
        };
    }

    private static int RunSearch(SearchEngine engine, string[] args)
    {
        int max = 5;
        string? source = null;
        string? platform = null;
        var queries = new List<string>();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--max" && i + 1 < args.Length && int.TryParse(args[++i], out var parsed))
            {
                max = parsed;
            }
            else if (args[i] == "--source" && i + 1 < args.Length)
            {
                source = ValidateSource(args[++i]);
                if (source == null) return 1;
            }
            else if (args[i] == "--platform" && i + 1 < args.Length)
            {
                platform = ValidatePlatform(args[++i]);
                if (platform == null) return 1;
            }
            else if (!args[i].StartsWith('-'))
            {
                queries.Add(args[i]);
            }
        }

        if (queries.Count == 0)
        {
            Console.Error.WriteLine("Usage: arcgis-dotnet-search search \"<query>\" [\"<query2>\" ...] [--max N] [--source runtime|toolkit|demo] [--platform wpf|winui|maui]");
            return 1;
        }

        if (queries.Count == 1)
        {
            EmitSearch(engine, queries[0], max, source, platform, includeHeader: false);
            return 0;
        }

        Console.WriteLine($"Batch search: {queries.Count} queries");
        for (int i = 0; i < queries.Count; i++)
        {
            Console.WriteLine($"### Query {i + 1}: \"{queries[i]}\"");
            EmitSearch(engine, queries[i], max, source, platform, includeHeader: true);
        }
        Console.WriteLine("To get full code/context: arcgis-dotnet-search get <id> [<id2> ...]");
        return 0;
    }

    private static void EmitSearch(SearchEngine engine, string query, int max, string? source, string? platform, bool includeHeader)
    {
        var results = engine.Search(query, max, source, platform);
        if (results.Count == 0)
        {
            Console.WriteLine($"No samples found for: \"{query}\"");
            return;
        }

        if (!includeHeader)
        {
            Console.WriteLine($"Found {results.Count} matches for \"{query}\":");
        }

        foreach (var result in results)
        {
            var s = result.Sample;
            var api = s.RelevantApis.Length > 0 ? $" APIs: {string.Join(", ", s.RelevantApis.Take(5))}" : "";
            Console.WriteLine($"  {s.Id}: [{s.Source}/{s.Platform}] {s.Title} — {s.Description}{api}");
        }

        if (!includeHeader)
        {
            Console.WriteLine("To get full code/context: arcgis-dotnet-search get <id> [<id2> ...]");
        }
    }

    private static int RunGet(SearchEngine engine, string[] ids)
    {
        if (ids.Length == 0)
        {
            Console.Error.WriteLine("Usage: arcgis-dotnet-search get <id> [<id2> ...]");
            return 1;
        }

        var anyMissing = false;
        for (int i = 0; i < ids.Length; i++)
        {
            if (i > 0) Console.WriteLine("---");
            var sample = engine.Get(ids[i]);
            if (sample == null)
            {
                Console.WriteLine($"Sample '{ids[i]}' not found.");
                anyMissing = true;
                continue;
            }

            PrintSample(sample);
        }

        return anyMissing ? 1 : 0;
    }

    private static int RunList(SearchEngine engine, string[] args)
    {
        string? source = null;
        string? platform = null;
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--source" && i + 1 < args.Length)
            {
                source = ValidateSource(args[++i]);
                if (source == null) return 1;
            }
            else if (args[i] == "--platform" && i + 1 < args.Length)
            {
                platform = ValidatePlatform(args[++i]);
                if (platform == null) return 1;
            }
        }

        foreach (var sample in engine.List(source, platform))
        {
            Console.WriteLine($"{sample.Id}: [{sample.Source}/{sample.Platform}] {sample.Title}");
        }

        return 0;
    }

    private static int RunDebug(SearchEngine engine, string[] args)
    {
        var query = string.Join(" ", args);
        var tokens = BM25.Tokenize(Synonyms.Preprocess(query));
        Console.WriteLine($"Query: \"{query}\"");
        Console.WriteLine($"Tokens: [{string.Join(", ", tokens)}]");
        Console.WriteLine($"Expanded: [{string.Join(", ", Synonyms.Expand(tokens))}]");
        foreach (var result in engine.Search(query, 20, null, null, applyFloor: false))
        {
            Console.WriteLine($"{result.Score,8:F3} {result.Sample.Id}: [{result.Sample.Source}/{result.Sample.Platform}] {result.Sample.Title}");
        }

        return 0;
    }

    private static void PrintSample(SampleEntry s)
    {
        Console.WriteLine($"## {s.Title} [{s.Source}/{s.Platform}]");
        Console.WriteLine(s.Description);
        Console.WriteLine($"**Source:** `{s.Repository}` `{s.Path}`");
        if (s.Keywords.Length > 0) Console.WriteLine($"**Keywords:** {string.Join(", ", s.Keywords)}");
        if (s.RelevantApis.Length > 0) Console.WriteLine($"**Relevant APIs:** {string.Join(", ", s.RelevantApis)}");
        if (s.Files.Length > 0) Console.WriteLine($"**Files:** {string.Join(", ", s.Files.Select(f => $"`{f}`"))}");
        if (!string.IsNullOrWhiteSpace(s.Xaml))
        {
            Console.WriteLine("**XAML:**");
            Console.WriteLine("```xml");
            Console.WriteLine(Normalize(s.Xaml));
            Console.WriteLine("```");
        }
        if (!string.IsNullOrWhiteSpace(s.CSharp))
        {
            Console.WriteLine("**C#:**");
            Console.WriteLine("```csharp");
            Console.WriteLine(Normalize(s.CSharp));
            Console.WriteLine("```");
        }
        if (s.Notes.Length > 0)
        {
            Console.WriteLine("**Notes:**");
            foreach (var note in s.Notes) Console.WriteLine($"- {note}");
        }
    }

    private static string Normalize(string text) => text.Replace("\r\n", "\n").Trim();

    private static string? ValidateSource(string raw)
    {
        var value = raw.ToLowerInvariant();
        if (value is "runtime" or "toolkit" or "demo") return value;
        Console.Error.WriteLine($"--source must be one of: runtime, toolkit, demo (got: {raw})");
        return null;
    }

    private static string? ValidatePlatform(string raw)
    {
        var value = raw.ToLowerInvariant();
        if (value is "wpf" or "winui" or "maui") return value;
        Console.Error.WriteLine($"--platform must be one of: wpf, winui, maui (got: {raw})");
        return null;
    }

    private static int PrintUsage()
    {
        Console.WriteLine("arcgis-dotnet-search - ArcGIS Maps SDK for .NET sample search");
        Console.WriteLine();
        Console.WriteLine("Commands:");
        Console.WriteLine("  search \"<q1>\" [\"<q2>\" ...] [--max N] [--source S] [--platform P]");
        Console.WriteLine("  get <id1> [<id2> ...]");
        Console.WriteLine("  list [--source S] [--platform P]");
        Console.WriteLine("  debug \"<query>\"");
        Console.WriteLine("  update-index [--output path] [--samples path] [--toolkit path] [--demos path] [--workdir path] [--keep]");
        Console.WriteLine();
        Console.WriteLine("Sources: runtime, toolkit, demo");
        Console.WriteLine("Platforms: wpf, winui, maui");
        return 1;
    }
}
