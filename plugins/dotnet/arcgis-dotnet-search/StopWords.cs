internal static class StopWords
{
    public static readonly HashSet<string> Common = new(StringComparer.OrdinalIgnoreCase)
    {
        "the","a","an","and","or","is","are","was","were","be","been","can","will",
        "that","this","it","its","in","on","of","to","for","with","by","from","as",
        "at","has","have","had","not","but","all","any","each","how","when","where",
        "which","who","you","your","we","our","they","them","their","also","more",
        "than","like","just","about","into","over","such","only","very","well","see",
        "use","used","using","set","get","make","made","create","created","sample",
        "samples","demo","app","application","arcgis","runtime","maps","sdk","dotnet",
        "net","csharp","xaml","true","false","basic","simple","show","display"
    };
}
