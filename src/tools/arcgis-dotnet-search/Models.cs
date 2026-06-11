using System.Text.Json.Serialization;

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(SampleEntry[]))]
internal partial class JsonContext : JsonSerializerContext { }

internal sealed class SampleEntry
{
    [JsonPropertyName("id")] public string Id { get; set; } = "";
    [JsonPropertyName("title")] public string Title { get; set; } = "";
    [JsonPropertyName("category")] public string Category { get; set; } = "";
    [JsonPropertyName("description")] public string Description { get; set; } = "";
    [JsonPropertyName("source")] public string Source { get; set; } = "";
    [JsonPropertyName("platform")] public string Platform { get; set; } = "";
    [JsonPropertyName("repository")] public string Repository { get; set; } = "";
    [JsonPropertyName("path")] public string Path { get; set; } = "";
    [JsonPropertyName("keywords")] public string[] Keywords { get; set; } = [];
    [JsonPropertyName("relevantApis")] public string[] RelevantApis { get; set; } = [];
    [JsonPropertyName("files")] public string[] Files { get; set; } = [];
    [JsonPropertyName("xaml")] public string? Xaml { get; set; }
    [JsonPropertyName("csharp")] public string? CSharp { get; set; }
    [JsonPropertyName("notes")] public string[] Notes { get; set; } = [];
}
