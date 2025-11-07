using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// 出力タイプ
/// </summary>
public enum LocalSearchDetail
{
    [EnumMember(Value = "simple")]
    Simple,
    [EnumMember(Value = "standard")]
    Standard,
    [EnumMember(Value = "full")]
    Full
}
