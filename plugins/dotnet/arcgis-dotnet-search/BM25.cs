using System.Text.RegularExpressions;

internal static partial class BM25
{
    private const double K1 = 1.2;
    private const double B = 0.75;

    internal sealed class Doc
    {
        public Dictionary<string, double> Tf { get; } = new(StringComparer.OrdinalIgnoreCase);
        public double Length { get; set; }
    }

    internal sealed class Corpus
    {
        public Dictionary<string, int> Df { get; } = new(StringComparer.OrdinalIgnoreCase);
        public int N { get; set; }
        public double AvgDl { get; set; }
    }

    [GeneratedRegex(@"[^a-z0-9\s\-]")]
    private static partial Regex NonAlphaRegex();

    public static string[] Tokenize(string text)
    {
        return NonAlphaRegex().Replace(text.ToLowerInvariant(), " ")
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(w => w.Length > 1 && !StopWords.Common.Contains(w))
            .ToArray();
    }

    public static Doc BuildDoc(params (string text, double weight)[] fields)
    {
        var doc = new Doc();
        foreach (var (text, weight) in fields)
        {
            foreach (var word in Tokenize(text))
            {
                doc.Tf[word] = doc.Tf.GetValueOrDefault(word) + weight;
                doc.Length += weight;
            }
        }

        return doc;
    }

    public static Corpus BuildCorpus(Doc[] docs)
    {
        var corpus = new Corpus { N = docs.Length };
        double totalLength = 0;
        foreach (var doc in docs)
        {
            totalLength += doc.Length;
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var word in doc.Tf.Keys)
            {
                if (seen.Add(word))
                {
                    corpus.Df[word] = corpus.Df.GetValueOrDefault(word) + 1;
                }
            }
        }

        corpus.AvgDl = totalLength / Math.Max(docs.Length, 1);
        return corpus;
    }

    public static double Score(Doc doc, string[] queryWords, Corpus corpus)
    {
        double score = 0;
        foreach (var word in queryWords)
        {
            if (!doc.Tf.TryGetValue(word, out var tf) || tf == 0)
            {
                continue;
            }

            var df = corpus.Df.GetValueOrDefault(word);
            var idf = Math.Log((corpus.N - df + 0.5) / (df + 0.5) + 1);
            var tfNorm = (tf * (K1 + 1)) / (tf + K1 * (1 - B + B * (doc.Length / Math.Max(corpus.AvgDl, 1))));
            score += idf * tfNorm;
        }

        return score;
    }
}
