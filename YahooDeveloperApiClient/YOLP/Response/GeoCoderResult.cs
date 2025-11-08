using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace YahooDeveloperApiClient.YOLP.Response;

/// <summary>
/// Yahoo!ジオコーダAPIのレスポンス結果
/// </summary>
public class GeoCoderResult
{
    /// <summary>
    /// レスポンスのまとめ情報
    /// </summary>
    public Result ResultInfo { get; set; }

    /// <summary>
    /// 検索結果の配列
    /// </summary>
    public FeatureInfo[] Feature { get; set; }

    /// <summary>
    /// レスポンス情報のサマリー
    /// </summary>
    public class Result
    {
        /// <summary>
        /// レスポンス情報に含まれる住所情報のデータ件数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 出力されている住所情報以外も含めた全データ件数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// レスポンス情報に含まれる住所情報の取得開始位置
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// リクエスト処理結果のステータス
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// レスポンス生成に要した時間
        /// </summary>
        public double Latency { get; set; }

        /// <summary>
        /// APIの説明文
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 検索結果1件分のデータ群
    /// </summary>
    public class FeatureInfo
    {
        /// <summary>
        /// 住所ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// グループID
        /// </summary>
        public string Gid { get; set; }

        /// <summary>
        /// 地域・拠点情報名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 図形情報
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
        /// プロパティ情報
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

            /// <summary>
            /// バウンディングボックス
            /// </summary>
            public string BoundingBox { get; set; }
        }

        /// <summary>
        /// プロパティ情報
        /// </summary>
        public class PropertyInfo
        {
            /// <summary>
            /// YOLP内部での識別ID
            /// </summary>
            public string Uid { get; set; }

            /// <summary>
            /// カセットID
            /// </summary>
            public string CassetteId { get; set; }

            /// <summary>
            /// 地域・拠点情報名の読み(カタカナ)
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
            /// 住所構造のデータ群
            /// </summary>
            public AddressElementInfo[] AddressElement { get; set; }

            /// <summary>
            /// 住所コード（JIS X 0402）
            /// </summary>
            public string GovernmentCode { get; set; }

            /// <summary>
            /// 住所マッチングレベル
            /// </summary>
            public string AddressMatchingLevel { get; set; }

            /// <summary>
            /// 詳細情報
            /// </summary>
            public DetailInfo Detail { get; set; }

            /// <summary>
            /// 住所とクエリーの一致度
            /// </summary>
            public string Approximation { get; set; }

            /// <summary>
            /// 国情報
            /// </summary>
            public class CountryInfo
            {
                /// <summary>
                /// 国コード（ISO 3166-1）
                /// </summary>
                public string Code { get; set; }

                /// <summary>
                /// 国名
                /// </summary>
                public string Name { get; set; }
            }

            /// <summary>
            /// 住所構造の各要素
            /// </summary>
            public class AddressElementInfo
            {
                /// <summary>
                /// 住所構造のレベル
                /// </summary>
                public string Level { get; set; }

                /// <summary>
                /// 住所名
                /// </summary>
                public string Name { get; set; }

                /// <summary>
                /// 読み（カナ）
                /// </summary>
                public string Kana { get; set; }

                /// <summary>
                /// 住所コード
                /// </summary>
                public string GovernmentCode { get; set; }
            }

            /// <summary>
            /// 詳細情報
            /// </summary>
            public class DetailInfo
            {
                /// <summary>
                /// 地域・拠点情報名の読み（ひらがな）
                /// </summary>
                public string NameHiragana { get; set; }

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
