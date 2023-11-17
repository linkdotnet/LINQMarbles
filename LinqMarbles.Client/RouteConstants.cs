using System.Collections.Frozen;
using System.Reflection;

namespace LinqMarbles;

public static class RouteConstant
{
    // Aggregation
    public const string Aggregate = "/aggregation/aggregate";
    public const string Average = "/aggregation/average";
    public const string Count = "/aggregation/count";
    public const string Max = "/aggregation/max";
    public const string MaxBy = "/aggregation/max-by";
    public const string Min = "/aggregation/min";
    public const string MinBy = "/aggregation/min-by";
    public const string Sum = "/aggregation/sum";
    
    // Concatenation
    public const string Concat = "/concatenation/concat";
    
    // Element
    public const string First = "/element/first";
    public const string FirstOrDefault = "/element/first-or-default";
    public const string Last = "/element/last";
    public const string LastOrDefault = "/element/last-or-default";
    public const string Single = "/element/single";
    public const string SingleOrDefault = "/element/single-or-default";
    
    // Filtering
    public const string Distinct = "/filtering/distinct";
    public const string Skip = "/filtering/skip";
    public const string Take = "/filtering/take";
    public const string Where = "/filtering/where";
    
    // Grouping
    public const string GroupBy = "/grouping/group-by";
    
    // Merging
    public const string GroupJoin = "/merging/group-join";
    public const string Join = "/merging/join";
    public const string Zip = "/merging/zip";
    
    // Order
    public const string Order = "/order/order";
    public const string OrderDescending = "/order/order-descending";
    
    // Projection
    public const string Select = "/projection/select";
    public const string SelectMany = "/projection/select-many";
    
    // Quantification
    public const string All = "/quantification/all";
    public const string Any = "/quantification/any";
    public const string Contains = "/quantification/contains";
    public const string SequenceEqual = "/quantification/sequence-equal";
    
    // Sequence
    public const string Chunk = "/sequence/chunk";
    
    // Set
    public const string Except = "/set/except";
    public const string Intersect = "/set/intersect";
    public const string Union = "/set/union";

    public static readonly FrozenDictionary<string, string[]> NavGroups = new Dictionary<string, string[]>
    {
        {
            "Aggregation", [
                RouteConstant.Aggregate,
                RouteConstant.Average,
                RouteConstant.Count,
                RouteConstant.Max,
                RouteConstant.MaxBy,
                RouteConstant.Min,
                RouteConstant.MinBy,
                RouteConstant.Sum
            ]
        },
        {
            "Concatenation", [
                RouteConstant.Concat
            ]
        },
        {
            "Element", [
                RouteConstant.First,
                RouteConstant.FirstOrDefault,
                RouteConstant.Last,
                RouteConstant.LastOrDefault,
                RouteConstant.Single,
                RouteConstant.SingleOrDefault
            ]
        },
        {
            "Filtering", [
                RouteConstant.Distinct,
                RouteConstant.Skip,
                RouteConstant.Take,
                RouteConstant.Where
            ]
        },
        { "Grouping", [
                RouteConstant.GroupBy] 
        },
        { "Merging", [
                RouteConstant.GroupJoin,
                RouteConstant.Join,
                RouteConstant.Zip] 
        },
        { "Order", [
                RouteConstant.Order,
                RouteConstant.OrderDescending] 
        },
        { "Projection", [
                RouteConstant.Select,
                RouteConstant.SelectMany] 
        },
        { "Quantification", [
                RouteConstant.All,
                RouteConstant.Any,
                RouteConstant.Contains,
                RouteConstant.SequenceEqual] 
        },
        { "Sequence", [
                RouteConstant.Chunk] 
        },
        { "Set", [
                RouteConstant.Except,
                RouteConstant.Intersect,
                RouteConstant.Union] 
        }
    }.ToFrozenDictionary();
    

    public static string GetRelativePath(this string path) => path.TrimStart('/');
    public static string GetPathTitle(this string path)
    {
        return string.Join(' ', path
            .Split('/')
            .Last()
            .Split('-')
            .Select(x => x[0].ToString().ToUpper() + x[1..]));
    }

    public static IEnumerable<string> GetAllRoutes()
    {
        return typeof(RouteConstant)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(x => x is { IsLiteral: true, IsInitOnly: false } && x.FieldType == typeof(string))
            .Select(x => x.GetValue(null)!.ToString()!)
            .ToList();
    }
}