using System.Collections.Frozen;

namespace LinqMarbles.Client
{
    public static class Routes
    {
        public static readonly FrozenDictionary<string, string[]> NavGroup = new Dictionary<string, string[]>
        {
            { "Aggregation", ["Aggregate", "Average", "Count", "Max", "MaxBy", "Min", "MinBy", "Sum"] },
            { "Concatenation", [ "Concat" ] },
            { "Element", [ "First", "FirstOrDefault", "Last", "LastOrDefault", "Single", "SingleOrDefault" ] },
            { "Filtering", [ "Distinct", "Skip", "Take", "Where" ] },
            { "Grouping", [ "GroupBy" ] },
            { "Merging", [ "GroupJoin", "Join", "Zip" ] },
            { "Order", [ "Order", "OrderDescending" ] },
            { "Projection", [ "Select", "SelectMany" ] },
            { "Quantification", [ "All", "Any", "Contains", "SequenceEqual" ] },
            { "Sequence", [ "Chunk" ] },
            { "Set", [ "Except", "Intersect", "Union" ] },
        }.ToFrozenDictionary();
        
        public static string FormatLinkHref(string link) => 
            "/" + string.Concat(link.Select((c, i) => i > 0 && char.IsUpper(c) ? "-" + c : c.ToString())).ToLower();
    }
}
