using System;
using System.Diagnostics.CodeAnalysis;
using Cysharp.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using YahooDeveloperApiClient.Configuration;
using YahooDeveloperApiClient.Https;
using YahooDeveloperApiClient.YOLP.Request;
using YahooDeveloperApiClient.YOLP.Response;

namespace YahooDeveloperApiClient.YOLP;

public interface IYOLPClient
{
    /// <summary>
    /// グルメAPIを実行して結果を取得する
    /// </summary>
    /// <param name="message">位置情報</param>
    /// <param name="genreCode">ジャンルコード</param>
    /// <returns>実行結果</returns>
    Task<LocalSearchResult> GetLocalSearchResultAsync(LocalSearchRequest request);

    /// <summary>
    /// ジオコーダAPIを実行して結果を取得する
    /// </summary>
    /// <param name="request">住所検索条件</param>
    /// <returns>実行結果</returns>
    Task<GeoCoderResult> GetGeoCoderResultAsync(GeoCoderRequest request);

    /// <summary>
    /// リバースジオコーダAPIを実行して結果を取得する
    /// </summary>
    /// <param name="request">座標</param>
    /// <returns>実行結果</returns>
    Task<ReverseGeoCoderResult> GetReverseGeoCoderResultAsync(ReverseGeoCoderRequest request);
}

/// <summary>
/// YahooAPI用のHTTPクライアント
/// </summary>
[ExcludeFromCodeCoverage]
public class YOLPClient : IYOLPClient
{
    /// <summary>
    /// HttpClient
    /// </summary>
    private HttpAdapter Http { get; }

    /// <summary>
    /// 設定情報
    /// </summary>
    private string AppId { get; }

    /// <summary>
    /// ベースURL
    /// </summary>
    private string BaseUrl { get; } = "https://map.yahooapis.jp";

    /// <summary>
    /// DIコンテナ用コンストラクタ
    /// </summary>
    /// <param name="http">HttpClient</param>
    /// <param name="opt">設定オプション</param>
    [ActivatorUtilitiesConstructor]
    public YOLPClient(HttpClient http, IOptions<YOLPClientOptions> opt)
    {
        Http = new HttpAdapter(http);
        AppId = opt.Value.AppId;
    }

    /// <summary>
    /// すでにHttpClientがある場合のコンストラクタ
    /// </summary>
    /// <param name="http">HttpClient</param>
    /// <param name="appId">アプリケーションID</param>
    public YOLPClient(HttpClient http, string appId)
    {
        Http = new HttpAdapter(http);
        AppId = appId;
    }

    /// <summary>
    /// HttpClientも自分で作る場合のコンストラクタ
    /// </summary>
    /// <param name="appId">アプリケーションID</param>
    public YOLPClient(string appId)
    {
        Http = new HttpAdapter(new HttpClient());
        AppId = appId;
    }

    /// <summary>
    /// グルメAPIを実行して結果を取得する
    /// </summary>
    /// <param name="dto">位置情報、ジャンルコード</param>
    /// <returns>実行結果</returns>
    public async Task<LocalSearchResult> GetLocalSearchResultAsync(LocalSearchRequest request)
    {
        var baseUrl = $"{BaseUrl}/search/local/V1/localSearch?appid={AppId}&output=json";
        return await Http.GetAsync<LocalSearchResult>(NormalizeQueryString(WebSerializer.ToQueryString(baseUrl, request)));
    }

    /// <summary>
    /// ジオコーダAPIを実行して結果を取得する
    /// </summary>
    /// <param name="request">住所検索条件</param>
    /// <returns>実行結果</returns>
    public async Task<GeoCoderResult> GetGeoCoderResultAsync(GeoCoderRequest request)
    {
        var baseUrl = $"{BaseUrl}/geocode/V1/geoCoder?appid={AppId}&output=json";
        return await Http.GetAsync<GeoCoderResult>(NormalizeQueryString(WebSerializer.ToQueryString(baseUrl, request)));
    }

    /// <summary>
    /// リバースジオコーダAPIを実行して結果を取得する
    /// </summary>
    /// <param name="request">座標</param>
    /// <returns>実行結果</returns>
    public async Task<ReverseGeoCoderResult> GetReverseGeoCoderResultAsync(ReverseGeoCoderRequest request)
    {
        var baseUrl = $"{BaseUrl}/geoapi/V1/reverseGeoCoder?appid={AppId}&output=json";
        return await Http.GetAsync<ReverseGeoCoderResult>(NormalizeQueryString(WebSerializer.ToQueryString(baseUrl, request)));
    }

    private static string NormalizeQueryString(string url)
    {
        var normalized = url.Replace("?&", "?");
        while (normalized.Contains("&&", StringComparison.Ordinal))
        {
            normalized = normalized.Replace("&&", "&");
        }

        return normalized;
    }
}
