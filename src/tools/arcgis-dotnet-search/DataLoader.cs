using System.Reflection;
using System.Text.Json;

internal static class DataLoader
{
    public static SampleEntry[] LoadSamples()
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("samples.json");
        if (stream == null)
        {
            throw new InvalidOperationException("Embedded samples.json resource was not found.");
        }

        return JsonSerializer.Deserialize(stream, JsonContext.Default.SampleEntryArray) ?? [];
    }
}
