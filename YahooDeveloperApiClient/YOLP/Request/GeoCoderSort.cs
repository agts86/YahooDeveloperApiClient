using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// ジオコーダ結果のソート方法
/// </summary>
public enum GeoCoderSort
{
    /// <summary>
    /// 適合度順
    /// </summary>
    [EnumMember(Value = "score")]
    Score,

    /// <summary>
    /// 距離順
    /// </summary>
    [EnumMember(Value = "dist")]
    Distance,

    /// <summary>
    /// かな昇順
    /// </summary>
    [EnumMember(Value = "kana")]
    Kana,

    /// <summary>
    /// かな降順
    /// </summary>
    [EnumMember(Value = "-kana")]
    KanaDescending,

    /// <summary>
    /// 住所階層順
    /// </summary>
    [EnumMember(Value = "address")]
    Address,

    /// <summary>
    /// よく検索される住所順
    /// </summary>
    [EnumMember(Value = "address2")]
    Address2
}
