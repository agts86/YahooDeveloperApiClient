using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// 喫煙の可否
/// </summary>
public enum LocalSearchSmoking
{
    [EnumMember(Value = "1")]
    Non,
    [EnumMember(Value = "2")]
    Separate,
    [EnumMember(Value = "3")]
    Enabled
}
