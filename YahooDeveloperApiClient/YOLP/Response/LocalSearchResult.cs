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
        /// カテゴリ情報（複数指定可能）
        /// </summary>
        public string[] Category { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// スタイル情報
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
            /// 住所コード（日本工業規格（JIS） X 0401 5けた）
            /// </summary>
            public string GovernmentCode { get; set; }

            /// <summary>                                               
            /// 最寄駅情報（最大3件）
            /// </summary>
            public StationInfo[] Station { get; set; }

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
            /// クーポンの有無
            /// </summary>
            public string CouponFlag { get; set; }

            /// <summary>
            /// クーポン情報
            /// </summary>
            public CouponInfo[] Coupon { get; set; }

            /// <summary>
            /// クレジットカード利用可否
            /// </summary>
            public string CreditcardFlag { get; set; }

            /// <summary>
            /// 駐車場の有無
            /// </summary>
            public string ParkingFlag { get; set; }

            /// <summary>
            /// 評価（5点満点）
            /// </summary>
            public double Rating { get; set; }

            /// <summary>
            /// エリア情報
            /// </summary>
            public AreaInfo[] Area { get; set; }

            /// <summary>
            /// 詳細情報
            /// </summary>
            public DetailInfo Detail { get; set; }

            /// <summary>
            /// キープ数
            /// </summary>
            public string KeepCount { get; set; }

            /// <summary>
            /// 値段
            /// </summary>
            public int Price { get; set; }

            /// <summary>
            /// 平均予算
            /// </summary>
            public string AveragePriceComment { get; set; }

            /// <summary>
            /// 代表画像
            /// </summary>
            public string LeadImage { get; set; }

            /// <summary>
            /// 作成日時（YYYY-MM-DD HH:mm形式）
            /// </summary>
            public string CreateDate { get; set; }

            /// <summary>
            /// 更新日時（YYYY-MM-DD HH:mm形式）
            /// </summary>
            public string UpdateDate { get; set; }

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
                /// 駅サブID
                /// </summary>
                public string SubId { get; set; }

                /// <summary>
                /// 駅名
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// 駅名読み（ひらがな）
                /// </summary>
                public string StaitionHiragana { get; set; }

                /// <summary>
                /// 路線名
                /// </summary>
                public string Railway { get; set; }

                /// <summary>
                /// 駅出口ID
                /// </summary>
                public string ExitId { get; set; }

                /// <summary>
                /// 駅出口
                /// </summary>
                public string Exit { get; set; }

                /// <summary>
                /// 駅出口名称
                /// </summary>
                public string ExitName { get; set; }

                /// <summary>
                /// 距離（駅までの距離）
                /// </summary>
                public string Distance { get; set; }

                /// <summary>
                /// 時間（分）（駅までの時間）
                /// </summary>
                public string Time { get; set; }

                /// <summary>
                /// 駅備考
                /// </summary>
                public string StationComment { get; set; }
            }

            /// <summary>
            /// ジャンル情報
            /// </summary>
            public class GenreInfo
            {
                /// <summary>
                /// ジャンル名
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// ジャンルレベル
                /// </summary>
                public int Level { get; set; }

                /// <summary>
                /// ジャンルコード
                /// </summary>
                public string Code { get; set; }

                /// <summary>
                /// ジャンルタイプ
                /// </summary>
                public string Type { get; set; }
            }

            /// <summary>
            /// クーポン情報
            /// </summary>
            public class CouponInfo
            {
                /// <summary>
                /// クーポン名
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// クーポン内容
                /// </summary>
                public string Comment { get; set; }

                /// <summary>
                /// クーポン設定（1：自動更新、2：期間を指定）
                /// </summary>
                public int Setting { get; set; }

                /// <summary>
                /// クーポン開始日（YYYY-MM-DD形式）
                /// </summary>
                public string StartDay { get; set; }

                /// <summary>
                /// クーポン終了日（YYYY-MM-DD形式）
                /// </summary>
                public string EndDay { get; set; }

                /// <summary>
                /// クーポンモバイルフラグ
                /// </summary>
                public string MobileFlag { get; set; }

                /// <summary>
                /// 他媒体のクーポンフラグ
                /// </summary>
                public string OtherMediaFlag { get; set; }

                /// <summary>
                /// クーポン一覧URL（PC）
                /// </summary>
                public string ParentPcUrl { get; set; }

                /// <summary>
                /// クーポン一覧URL（スマートフォン）
                /// </summary>
                public string ParentSmartPhoneUrl { get; set; }

                /// <summary>
                /// クーポン一覧URL（モバイル）
                /// </summary>
                public string ParentMobileUrl { get; set; }

                /// <summary>
                /// 拡張データ
                /// </summary>
                [JsonExtensionData]
                public Dictionary<string, JsonElement> Extra { get; init; } = new(StringComparer.OrdinalIgnoreCase);
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
                /// 住所
                /// </summary>
                public string DisplayAddress { get; set; }

                /// <summary>
                /// 営業時間
                /// </summary>
                public string BusinessHour { get; set; }

                /// <summary>
                /// Fax番号
                /// </summary>
                public string Fax1 { get; set; }

                /// <summary>
                /// アクセス方法
                /// </summary>
                public string Access1 { get; set; }

                /// <summary>
                /// 支払い方法
                /// </summary>
                public string Payment { get; set; }

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
                /// カラオケがあるお店
                /// </summary>
                public bool? KaraokeFlag { get; set; }

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
