internal static class Synonyms
{
    public static readonly Dictionary<string, string> Phrases = new(StringComparer.OrdinalIgnoreCase)
    {
        ["map view"] = "mapview",
        ["scene view"] = "sceneview",
        ["feature layer"] = "featurelayer",
        ["graphics overlay"] = "graphicsoverlay",
        ["mobile map package"] = "mmpk",
        ["mobile geodatabase"] = "geodatabase",
        ["offline map"] = "offline",
        ["utility network"] = "utilitynetwork",
        ["route task"] = "routing",
        ["geocode task"] = "geocode",
        ["identify layer"] = "identify",
        ["identify graphics"] = "identify",
        ["callout"] = "popup"
    };

    public static readonly Dictionary<string, string[]> Map = new(StringComparer.OrdinalIgnoreCase)
    {
        ["auth"] = ["authentication", "oauth", "credential"],
        ["login"] = ["oauth", "authentication", "signin"],
        ["signin"] = ["oauth", "authentication", "login"],
        ["location"] = ["gps", "geolocation", "locationdisplay"],
        ["gps"] = ["location", "nmea", "locationdisplay"],
        ["offline"] = ["mmpk", "geodatabase", "sync", "download"],
        ["sync"] = ["geodatabase", "offline", "synchronize"],
        ["routing"] = ["route", "directions", "network"],
        ["directions"] = ["routing", "route"],
        ["search"] = ["geocode", "locator", "query"],
        ["popup"] = ["callout", "identify", "feature"],
        ["identify"] = ["popup", "callout", "tapped", "selection"],
        ["sketch"] = ["geometryeditor", "draw", "edit"],
        ["edit"] = ["geometryeditor", "feature", "editing"],
        ["3d"] = ["scene", "sceneview"],
        ["ar"] = ["augmented", "reality", "sceneview"],
        ["toc"] = ["tableofcontents", "layers"],
        ["basemap"] = ["basemapgallery", "basemap"],
        ["legend"] = ["layerlegend", "legend"]
    };

    public static string Preprocess(string query)
    {
        var lower = query.ToLowerInvariant();
        var sb = new System.Text.StringBuilder(lower);
        foreach (var (phrase, token) in Phrases)
        {
            if (lower.Contains(phrase, StringComparison.OrdinalIgnoreCase))
            {
                sb.Append(' ').Append(token);
            }
        }

        return sb.ToString();
    }

    public static string[] Expand(string[] queryWords)
    {
        var result = new List<string>(queryWords);
        var seen = new HashSet<string>(queryWords, StringComparer.OrdinalIgnoreCase);
        foreach (var word in queryWords)
        {
            if (!Map.TryGetValue(word, out var synonyms))
            {
                continue;
            }

            foreach (var synonym in synonyms)
            {
                if (seen.Add(synonym))
                {
                    result.Add(synonym);
                }
            }
        }

        return result.ToArray();
    }
}
