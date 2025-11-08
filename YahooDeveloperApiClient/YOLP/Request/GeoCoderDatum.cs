using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// 緯度経度の測地系
/// </summary>
public enum GeoCoderDatum
{
    /// <summary>
    /// 世界測地系
    /// </summary>
    [EnumMember(Value = "wgs")]
    WorldGeodetic,

    /// <summary>
    /// 日本測地系
    /// </summary>
    [EnumMember(Value = "tky")]
    Tokyo
}
