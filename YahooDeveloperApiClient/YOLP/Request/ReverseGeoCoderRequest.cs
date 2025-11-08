using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// Yahoo!リバースジオコーダAPIのリクエストパラメータ
/// </summary>
[DataContract]
public class ReverseGeoCoderRequest
{
    /// <summary>
    /// 緯度（世界測地系）
    /// </summary>
    [DataMember(Name = "lat", IsRequired = true)]
    public double Lat { get; set; }

    /// <summary>
    /// 経度（世界測地系）
    /// </summary>
    [DataMember(Name = "lon", IsRequired = true)]
    public double Lon { get; set; }

    /// <summary>
    /// 測地系
    /// </summary>
    [DataMember(Name = "datum")]
    public GeoCoderDatum? Datum { get; set; }

    /// <summary>
    /// JSONPのコールバック関数名
    /// </summary>
    [DataMember(Name = "callback")]
    public string Callback { get; set; }
}
