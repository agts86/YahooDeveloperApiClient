using System.Runtime.Serialization;

namespace YahooDeveloperApiClient.YOLP.Request;

/// <summary>
/// 入力検索文字列のエンコード形式
/// </summary>
public enum GeoCoderEncoding
{
    /// <summary>
    /// UTF-8形式
    /// </summary>
    [EnumMember(Value = "UTF-8")]
    Utf8,

    /// <summary>
    /// EUC-JP形式
    /// </summary>
    [EnumMember(Value = "EUC-JP")]
    EucJp,

    /// <summary>
    /// Shift_JIS形式
    /// </summary>
    [EnumMember(Value = "SJIS")]
    ShiftJis
}
