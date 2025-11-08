using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// YDFの出力詳細レベル
/// </summary>
public enum YdfDetailLevel
{
    [EnumMember(Value = "simple")]
    Simple,
    [EnumMember(Value = "standard")]
    Standard,
    [EnumMember(Value = "full")]
    Full
}
