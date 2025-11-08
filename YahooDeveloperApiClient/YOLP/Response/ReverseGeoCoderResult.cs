namespace YahooDeveloperApiClient.YOLP.Response;

/// <summary>
/// Yahoo!リバースジオコーダAPIのレスポンス結果
/// </summary>
public class ReverseGeoCoderResult
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
        public int Count { get; set; }
        public int Total { get; set; }
        public int Start { get; set; }
        public double Latency { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// 検索結果1件分のデータ群
    /// </summary>
    public class FeatureInfo
    {
        /// <summary>
        /// 位置情報
        /// </summary>
        public GeometryInfo Geometry { get; set; }

        /// <summary>
        /// プロパティ情報
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// ジオメトリ情報
        /// </summary>
        public class GeometryInfo
        {
            public string Type { get; set; }
            public string Coordinates { get; set; }
        }

        /// <summary>
        /// プロパティ情報
        /// </summary>
        public class PropertyInfo
        {
            public CountryInfo Country { get; set; }
            public string Address { get; set; }
            public AddressElementInfo[] AddressElement { get; set; }
            public BuildingInfo[] Building { get; set; }
            public RoadInfo Road { get; set; }

            public class CountryInfo
            {
                public string Code { get; set; }
                public string Name { get; set; }
            }

            public class AddressElementInfo
            {
                public string Level { get; set; }
                public string Code { get; set; }
                public string Name { get; set; }
                public string Kana { get; set; }
            }

            public class BuildingInfo
            {
                public string Id { get; set; }
                public string Name { get; set; }
                public string Floor { get; set; }
                public string Area { get; set; }
            }

            public class RoadInfo
            {
                public string Name { get; set; }
                public string Kana { get; set; }
                public string PopularName { get; set; }
                public string PopularKana { get; set; }
            }
        }
    }
}
