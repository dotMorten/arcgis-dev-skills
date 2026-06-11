internal sealed class SearchEngine
{
    private readonly SampleEntry[] _samples;
    private readonly BM25.Doc[] _docs;
    private readonly BM25.Corpus _corpus;

    public SearchEngine(SampleEntry[] samples)
    {
        _samples = samples;
        _docs = samples.Select(s => BM25.BuildDoc(
            (s.Title, 4.0),
            (s.Category, 2.5),
            (s.Description, 2.0),
            (string.Join(" ", s.Keywords), 3.0),
            (string.Join(" ", s.RelevantApis), 4.0),
            (s.Platform, 1.5),
            (s.Source, 1.5),
            (s.Path, 0.5),
            (s.Xaml ?? "", 0.25),
            (s.CSharp ?? "", 0.25)
        )).ToArray();
        _corpus = BM25.BuildCorpus(_docs);
    }

    public sealed record SearchResult(SampleEntry Sample, double Score);

    public List<SearchResult> Search(string query, int max, string? source, string? platform, bool applyFloor = true)
    {
        var words = Synonyms.Expand(BM25.Tokenize(Synonyms.Preprocess(query)));
        if (words.Length == 0)
        {
            return [];
        }

        var compactQuery = Compact(query);
        var results = new List<SearchResult>();
        for (int i = 0; i < _samples.Length; i++)
        {
            var sample = _samples[i];
            if (source != null && !sample.Source.Equals(source, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            if (platform != null && !sample.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var score = BM25.Score(_docs[i], words, _corpus);
            var compactTitle = Compact(sample.Title);
            var compactCategory = Compact(sample.Category);
            if (compactTitle.Length > 4 && compactQuery.Contains(compactTitle, StringComparison.Ordinal))
            {
                score *= 3.0;
            }
            else if (compactCategory.Length > 4 && compactQuery.Contains(compactCategory, StringComparison.Ordinal))
            {
                score *= 1.8;
            }

            if (score > 0)
            {
                results.Add(new SearchResult(sample, score));
            }
        }

        results.Sort((a, b) => b.Score.CompareTo(a.Score));
        if (applyFloor && results.Count > 1)
        {
            var floor = results[0].Score * 0.35;
            results = results.Where((r, i) => i == 0 || r.Score >= floor).ToList();
        }

        return results.Take(max).ToList();
    }

    public SampleEntry? Get(string id) =>
        _samples.FirstOrDefault(s => s.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<SampleEntry> List(string? source, string? platform) =>
        _samples
            .Where(s => source == null || s.Source.Equals(source, StringComparison.OrdinalIgnoreCase))
            .Where(s => platform == null || s.Platform.Equals(platform, StringComparison.OrdinalIgnoreCase))
            .OrderBy(s => s.Source)
            .ThenBy(s => s.Platform)
            .ThenBy(s => s.Category)
            .ThenBy(s => s.Title);

    private static string Compact(string text)
    {
        var sb = new System.Text.StringBuilder(text.Length);
        foreach (var c in text.ToLowerInvariant())
        {
            if (char.IsLetterOrDigit(c))
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}
