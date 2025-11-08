using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// 住所レベルの範囲指定
/// </summary>
public enum GeoCoderAddressRange
{
    /// <summary>
    /// 以上
    /// </summary>
    [EnumMember(Value = "ge")]
    GreaterOrEqual,

    /// <summary>
    /// 以下
    /// </summary>
    [EnumMember(Value = "le")]
    LessOrEqual,

    /// <summary>
    /// 等しい
    /// </summary>
    [EnumMember(Value = "eq")]
    Equal
}
