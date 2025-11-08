using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// 住所検索レベル
/// </summary>
public enum GeoCoderAddressLevel
{
    /// <summary>
    /// 都道府県レベル
    /// </summary>
    [EnumMember(Value = "1")]
    Prefecture = 1,

    /// <summary>
    /// 市区町村レベル
    /// </summary>
    [EnumMember(Value = "2")]
    Municipality = 2,

    /// <summary>
    /// 町・大字レベル
    /// </summary>
    [EnumMember(Value = "3")]
    District = 3,

    /// <summary>
    /// 丁目・字レベル
    /// </summary>
    [EnumMember(Value = "4")]
    Block = 4
}
