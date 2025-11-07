using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// ソート方法
/// </summary>
public enum LocalSearchSort
{
    [EnumMember(Value = "score")]
    Score,
    [EnumMember(Value = "rating")]
    Rating,
    [EnumMember(Value = "review")]
    Review,
    [EnumMember(Value = "hybrid")]
    Hybrid,
    [EnumMember(Value = "name")]
    Name,
    [EnumMember(Value = "distance")]
    Distance,
    [EnumMember(Value = "kan_lat")]
    KanLat,
    [EnumMember(Value = "pref_dist")]
    PrefDist,
    [EnumMember(Value = "area_code")]
    AreaCode,
    [EnumMember(Value = "gc_id")]
    GcId,
    [EnumMember(Value = "match")]
    Match
}
