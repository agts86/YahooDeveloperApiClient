using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// Yahoo!ジオコーダAPIのリクエストパラメータ
/// </summary>
[DataContract]
public class GeoCoderRequest
{
    /// <summary>
    /// 住所検索クエリー（UTF-8でエンコードされた文字列）
    /// </summary>
    [DataMember(Name = "query")]
    public string Query { get; set; }

    /// <summary>
    /// 入力文字列のエンコード形式
    /// </summary>
    [DataMember(Name = "ei")]
    public GeoCoderEncoding? Encoding { get; set; }

    /// <summary>
    /// 中心の緯度
    /// </summary>
    [DataMember(Name = "lat")]
    public double? Lat { get; set; }

    /// <summary>
    /// 中心の経度
    /// </summary>
    [DataMember(Name = "lon")]
    public double? Lon { get; set; }

    /// <summary>
    /// 矩形範囲（左下経度,左下緯度,右上経度,右上緯度）
    /// </summary>
    [DataMember(Name = "bbox")]
    public string Bbox { get; set; }

    /// <summary>
    /// 測地系
    /// </summary>
    [DataMember(Name = "datum")]
    public GeoCoderDatum? Datum { get; set; }

    /// <summary>
    /// 住所コード（JIS X 0401/0402）
    /// </summary>
    [DataMember(Name = "ac")]
    public string AreaCode { get; set; }

    /// <summary>
    /// 住所検索レベル
    /// </summary>
    [DataMember(Name = "al")]
    public GeoCoderAddressLevel? AddressLevel { get; set; }

    /// <summary>
    /// 住所レベルの範囲
    /// </summary>
    [DataMember(Name = "ar")]
    public GeoCoderAddressRange? AddressRange { get; set; }

    /// <summary>
    /// trueを指定するとマッチしなかった場合に上位レベルを再検索
    /// </summary>
    [DataMember(Name = "recursive")]
    public bool? Recursive { get; set; }

    /// <summary>
    /// ソート順
    /// </summary>
    [DataMember(Name = "sort")]
    public GeoCoderSort? Sort { get; set; }

    /// <summary>
    /// falseを指定すると都道府県レコードも検索対象に含める
    /// </summary>
    [DataMember(Name = "exclude_prefecture")]
    public bool? ExcludePrefecture { get; set; }

    /// <summary>
    /// falseを指定すると政令指定都市レコードも検索対象に含める
    /// </summary>
    [DataMember(Name = "exclude_seireishi")]
    public bool? ExcludeSeireishi { get; set; }

    /// <summary>
    /// 表示開始位置（最大100）
    /// </summary>
    [DataMember(Name = "start")]
    [Range(1, 100)]
    public int? Start { get; set; }

    /// <summary>
    /// ページ数（startと排他）
    /// </summary>
    [DataMember(Name = "page")]
    [Range(1, 100)]
    public int? Page { get; set; }

    /// <summary>
    /// 表示件数（最大100）
    /// </summary>
    [DataMember(Name = "results")]
    [Range(1, 100)]
    public int? Results { get; set; }

    /// <summary>
    /// JSONPのコールバック関数名
    /// </summary>
    [DataMember(Name = "callback")]
    public string Callback { get; set; }

    /// <summary>
    /// 出力項目数
    /// </summary>
    [DataMember(Name = "detail")]
    public YdfDetailLevel? Detail { get; set; }
}
