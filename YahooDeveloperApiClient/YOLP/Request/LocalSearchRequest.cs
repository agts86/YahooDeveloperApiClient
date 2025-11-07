using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// Yahoo!ローカルサーチAPIのリクエストパラメータ
/// </summary>
[DataContract]
public class LocalSearchRequest
{
    /// <summary>
    /// APIの結果をモバイル端末に掲載する場合は「mobile」を指定
    /// </summary>
    [DataMember(Name = "device")]
    public string Device { get; set; }

    // ID/検索
    /// <summary>
    /// UTF-8でエンコードされた検索クエリー（地域・拠点情報名称および業種が検索対象）
    /// </summary>
    [DataMember(Name = "query")]
    public string Query { get; set; }

    /// <summary>
    /// カセットID（コンマ区切りで複数指定可能）
    /// </summary>
    [DataMember(Name = "cid")]
    public string Cid { get; set; }

    /// <summary>
    /// 名寄せされた店舗ID（コンマ区切りで複数指定可能）
    /// </summary>
    [DataMember(Name = "gid")]
    public string Gid { get; set; }

    /// <summary>
    /// カセット内で設定されたID（コンマ区切りで複数指定可能）
    /// </summary>
    [DataMember(Name = "id")]
    public string Id { get; set; }

    /// <summary>
    /// ビルID（コンマ区切りで複数指定可能、変更になる場合があります）
    /// </summary>
    [DataMember(Name = "bid")]
    public string Bid { get; set; }

    // 集約・重複排除
    /// <summary>
    /// gidを指定すると名寄せされた同一店舗をまとめて表示
    /// </summary>
    [DataMember(Name = "group")]
    public string Group { get; set; }

    /// <summary>
    /// group=gid時に重複レコードの表示を指定（デフォルトはtrue）
    /// </summary>
    [DataMember(Name = "distinct")]
    public bool? Distinct { get; set; }

    // 並び順
    /// <summary>
    /// ソート方法（rating, score, hybrid, review, kana, price, dist, geo, match）
    /// </summary>
    [DataMember(Name = "sort")]
    public LocalSearchSort? Sort { get; set; }

    // ページング
    /// <summary>
    /// 取得開始位置を指定（最大3000）
    /// </summary>
    [DataMember(Name = "start")]
    [Range(0, 3000)]
    public int? Start { get; set; }

    /// <summary>
    /// 取得件数を指定（最大100）
    /// </summary>
    [DataMember(Name = "results")]
    [Range(1, 100)]
    public int? Results { get; set; }

    // 詳細度・出力
    /// <summary>
    /// 出力項目数（simple, standard, full）
    /// </summary>
    [DataMember(Name = "detail")]
    public LocalSearchDetail? Detail { get; set; }

    /// <summary>
    /// JSONPとして出力する際のコールバック関数名（UTF-8でエンコード）
    /// </summary>
    [DataMember(Name = "callback")]
    public string Callback { get; set; }

    // 位置・範囲
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
    /// 検索距離（km）最大20km、小数点も指定可能
    /// </summary>
    [DataMember(Name = "dist")]
    public double? Dist { get; set; }

    /// <summary>
    /// 矩形範囲の左下経度、左下緯度、右上経度、右上緯度を世界測地系十進形式で指定（コンマ区切り）
    /// </summary>
    [DataMember(Name = "bbox")]
    public string Bbox { get; set; }

    // 地域・業種
    /// <summary>
    /// 住所コード（JIS X 0401）または国コード（ISO 3166-1 alpha-2）
    /// </summary>
    [DataMember(Name = "ac")]
    public string AreaCode { get; set; }

    /// <summary>
    /// 業種コードを指定（YOLP業種コード）
    /// </summary>
    [DataMember(Name = "gc")]
    public string GenreCode { get; set; }

    // フィルタ（有無）
    /// <summary>
    /// trueを指定すると、クーポンが利用できる店舗データを対象に検索
    /// </summary>
    [DataMember(Name = "coupon")]
    public bool? Coupon { get; set; }

    /// <summary>
    /// trueを指定すると、駐車場がある店舗データを対象に検索
    /// </summary>
    [DataMember(Name = "parking")]
    public bool? Parking { get; set; }

    /// <summary>
    /// trueを指定すると、クレジットカードが利用できる店舗データを対象に検索
    /// </summary>
    [DataMember(Name = "creditcard")]
    public bool? CreditCard { get; set; }

    /// <summary>
    /// trueを指定すると、画像があるデータを対象に検索
    /// </summary>
    [DataMember(Name = "image")]
    public bool? Image { get; set; }

    // フィルタ（その他）
    /// <summary>
    /// 喫煙の可否を指定（1:禁煙、2:分煙、3:喫煙可、コンマ区切りで複数指定可能）
    /// </summary>
    [DataMember(Name = "smoking")]
    public LocalSearchSmoking? Smoking { get; set; }

    /// <summary>
    /// 予約ができる店舗データを対象に検索（1を指定）
    /// </summary>
    [DataMember(Name = "reserve")]
    public string Reserve { get; set; }

    /// <summary>
    /// 特定の日時に開店している施設を検索（date,hour / week,hour / now 形式）
    /// </summary>
    [DataMember(Name = "open")]
    public string Open { get; set; }

    /// <summary>
    /// 特別な検索機能を有効にする（3文字以下のクエリロジック変更など）
    /// </summary>
    [DataMember(Name = "loc_mode")]
    public string LocMode { get; set; }

    /// <summary>
    /// Priceタグの最大値を指定
    /// </summary>
    [DataMember(Name = "manprice")]
    public int? ManPrice { get; set; }

    /// <summary>
    /// Priceタグの最小値を指定
    /// </summary>
    [DataMember(Name = "minprice")]
    public int? MinPrice { get; set; }
}
