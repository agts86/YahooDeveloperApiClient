using System.Text.Json;
using System.Text.Json.Serialization;

namespace YahooDeveloperApiClient.YOLP.Response;

/// <summary>
/// Yahoo!ローカルサーチAPIのレスポンス結果
/// </summary>
public class LocalSearchResult
{
    /// <summary>
    /// レスポンスのまとめ情報
    /// </summary>
    public ResultDto ResultInfo { get; set; }

    /// <summary>
    /// レスポンス情報のサマリー
    /// </summary>
    public class ResultDto
    {
        /// <summary>
        /// レスポンス情報に含まれるデータ件数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 出力されている住所情報以外も含めた全データ件数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// レスポンス情報に含まれるデータの、全データからの取得開始位置
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// レスポンス情報を生成するのに要した時間
        /// </summary>
        public double Latency { get; set; }

        /// <summary>
        /// リクエスト元に処理結果を伝えるためのコード（正常終了の場合は200）
        /// </summary>
        public int Status { get; set; }
    }

    /// <summary>
    /// 検索結果の配列
    /// </summary>
    public FeatureInfo[] Feature { get; set; }

    /// <summary>
    /// 検索結果1件分のデータ群
    /// </summary>
    public class FeatureInfo
    {
        /// <summary>
        /// カセット内部のID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 拠点ごとに割り当てられた拠点の管理ID
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// 地域・拠点情報名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 拠点の場所を表すGeometry要素（世界測地系）
        /// </summary>
        public GeometryInfo Geometry { get; set; }

        /// <summary>
        /// カテゴリ情報
        /// </summary>
        public string[] Category { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// スタイル配列
        /// </summary>
        public string[] Style { get; set; }

        /// <summary>
        /// 地域・拠点情報の詳細要素
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// ジオメトリ情報
        /// </summary>
        public class GeometryInfo
        {
            /// <summary>
            /// 図形種別
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// 座標情報
            /// </summary>
            public string Coordinates { get; set; }
        }

        /// <summary>
        /// プロパティ情報
        /// </summary>
        public class PropertyInfo
        {
            /// <summary>
            /// Yahoo! Open Local Platform（YOLP）内部での識別ID
            /// </summary>
            public string Uid { get; set; }

            /// <summary>
            /// カセットID
            /// </summary>
            public string CassetteId { get; set; }

            /// <summary>
            /// 地域・拠点情報名の読み
            /// </summary>
            public string Yomi { get; set; }

            /// <summary>
            /// 国情報
            /// </summary>
            public CountryInfo Country { get; set; }

            /// <summary>
            /// 1行で表す住所
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// 住所要素の配列
            /// </summary>
            public AddressElementInfo[] AddressElement { get; set; }

            /// <summary>
            /// 住所コード（日本工業規格（JIS） X 0401 5けた）
            /// </summary>
            public string GovernmentCode { get; set; }

            /// <summary>
            /// 住所マッチングレベル
            /// </summary>
            public string AddressMatchingLevel { get; set; }

            /// <summary>
            /// 最寄駅情報（最大3件）
            /// </summary>
            public StationInfo[] Station { get; set; }

            /// <summary>
            /// 店舗が入る場所情報
            /// </summary>
            public PlaceInfo Place { get; set; }

            /// <summary>
            /// 電話番号
            /// </summary>
            public string Tel1 { get; set; }

            /// <summary>
            /// 店舗のジャンル（複数あり）
            /// </summary>
            public GenreInfo[] Genre { get; set; }

            /// <summary>
            /// ビル情報
            /// </summary>
            public BuildingInfo[] Building { get; set; }

            /// <summary>
            /// キャッチコピー
            /// </summary>
            public string CatchCopy { get; set; }

            /// <summary>
            /// レビュー数
            /// </summary>
            public int ReviewCount { get; set; }

            /// <summary>
            /// 作成日
            /// </summary>
            public string CreateDate { get; set; }

            /// <summary>
            /// スマートフォンクーポンフラグ
            /// </summary>
            public string SmartPhoneCouponFlag { get; set; }

            /// <summary>
            /// 営業状況
            /// </summary>
            public string OpenForBusiness { get; set; }

            /// <summary>
            /// 駐車場フラグ
            /// </summary>
            public string ParkingFlag { get; set; }

            /// <summary>
            /// クーポン配列
            /// </summary>
            public string[] Coupon { get; set; }

            /// <summary>
            /// エリア情報
            /// </summary>
            public AreaInfo[] Area { get; set; }

            /// <summary>
            /// 詳細情報
            /// </summary>
            public DetailInfo Detail { get; set; }

            /// <summary>
            /// エリア情報
            /// </summary>
            public class AreaInfo
            {
                /// <summary>
                /// エリアコード
                /// </summary>
                public string Code { get; set; }

                /// <summary>
                /// エリア名
                /// </summary>
                public string Name { get; set; }
            }

            /// <summary>
            /// 国情報
            /// </summary>
            public class CountryInfo
            {
                /// <summary>
                /// 国コード（国際標準化機構（ISO） 3166-1）
                /// </summary>
                public string Code { get; set; }

                /// <summary>
                /// 国名
                /// </summary>
                public string Name { get; set; }
            }

            /// <summary>
            /// 駅情報
            /// </summary>
            public class StationInfo
            {
                /// <summary>
                /// 駅ID
                /// </summary>
                public string Id { get; set; }

                /// <summary>
                /// 駅名
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// 代表路線名
                /// </summary>
                public string Railway { get; set; }

                /// <summary>
                /// 最寄りの駅出口名
                /// </summary>
                public string Exit { get; set; }

                /// <summary>
                /// 最寄りの駅出口ID
                /// </summary>
                public string ExitId { get; set; }

                /// <summary>
                /// 最寄駅出口からの距離（m）
                /// </summary>
                public string Distance { get; set; }

                /// <summary>
                /// 最寄駅出口からの徒歩時間
                /// </summary>
                public string Time { get; set; }

                /// <summary>
                /// 駅の位置情報
                /// </summary>
                public GeometryInfo Geometry { get; set; }
            }

            /// <summary>
            /// 場所情報
            /// </summary>
            public class PlaceInfo
            {
                /// <summary>
                /// フロア名
                /// </summary>
                public string FloorName { get; set; }

                /// <summary>
                /// 最適な地図の種別
                /// </summary>
                public string MapType { get; set; }

                /// <summary>
                /// この地域・拠点名を表示するのに適切な地図の縮尺
                /// </summary>
                public string MapScale { get; set; }
            }

            /// <summary>
            /// ジャンル情報
            /// </summary>
            public class GenreInfo
            {
                /// <summary>
                /// 業種コード
                /// </summary>
                public string Code { get; set; }

                /// <summary>
                /// ジャンル名
                /// </summary>
                public string Name { get; set; }
            }

            /// <summary>
            /// ビル情報
            /// </summary>
            public class BuildingInfo
            {
                /// <summary>
                /// ビルごとに割り当てられたID（ビルIDは変更になる場合があります）
                /// </summary>
                public string Id { get; set; }

                /// <summary>
                /// ビル名
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// 階数の情報
                /// </summary>
                public string Floor { get; set; }

                /// <summary>
                /// 面積
                /// </summary>
                public string Area { get; set; }
            }

            /// <summary>
            /// 住所要素情報
            /// </summary>
            public class AddressElementInfo
            {
                /// <summary>
                /// 住所要素名
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// 住所要素の読み仮名
                /// </summary>
                public string Kana { get; set; }

                /// <summary>
                /// 住所レベル（prefecture, city, oaza, aza など）
                /// </summary>
                public string Level { get; set; }
            }

            /// <summary>
            /// 詳細情報
            /// </summary>
            public class DetailInfo
            {
                /// <summary>
                /// 郵便番号
                /// </summary>
                public string ZipCode { get; set; }

                /// <summary>
                /// 標高
                /// </summary>
                public string Altitude { get; set; }

                /// <summary>
                /// 著作権情報
                /// </summary>
                public string Copyright { get; set; }

                /// <summary>
                /// カセットオーナー
                /// </summary>
                public string CassetteOwner { get; set; }

                /// <summary>
                /// カセットヘッダー
                /// </summary>
                public string CassetteHeader { get; set; }

                /// <summary>
                /// カセットフッター
                /// </summary>
                public string CassetteFooter { get; set; }

                /// <summary>
                /// カセットオーナーURL
                /// </summary>
                public string CassetteOwnerUrl { get; set; }

                /// <summary>
                /// カセットオーナーモバイルURL
                /// </summary>
                public string CassetteOwnerMobileUrl { get; set; }

                /// <summary>
                /// Fax番号
                /// </summary>
                public string Fax1 { get; set; }

                /// <summary>
                /// アクセス方法
                /// </summary>
                public string Access1 { get; set; }

                /// <summary>
                /// パソコンサイトのURL
                /// </summary>
                public string PcUrl1 { get; set; }

                /// <summary>
                /// モバイルサイトのURL
                /// </summary>
                public string MobileUrl1 { get; set; }

                /// <summary>
                /// レビューのURL
                /// </summary>
                public string ReviewUrl { get; set; }

                /// <summary>
                /// 画像情報
                /// </summary>
                public string Image1 { get; set; }

                /// <summary>
                /// 拡張データ
                /// </summary>
                [JsonExtensionData]
                public Dictionary<string, JsonElement> Extra { get; init; } = new(StringComparer.OrdinalIgnoreCase);

                /// <summary>
                /// 拡張データを取得します。
                /// </summary>
                /// <param name="key">キー</param>
                /// <typeparam name="T">値の型</typeparam>
                /// <returns>値</returns>
                public T GetExtraValue<T>(string key)
                {
                    if (Extra != null && Extra.TryGetValue(key, out var value))
                        return value.Deserialize<T>();
                    return default;
                }
            }
        }
    }
}
