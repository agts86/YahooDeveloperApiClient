using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using YahooDeveloperApiClient.YOLP;

namespace YahooDeveloperApiClient.Configuration;

/// <summary>
/// Yahoo!ローカルサーチAPIのサービスコレクション拡張メソッド
/// </summary>
[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Yahoo!ローカルサーチAPIのクライアントをサービスコレクションに追加します。
    /// </summary>
    /// <param name="services">サービスコレクション</param>
    /// <param name="configure">クライアントオプションの設定</param>
    /// <returns>サービスコレクション</returns>
    public static IServiceCollection AddYOLPClient(
        this IServiceCollection services,
        Action<YOLPClientOptions> configure)
    {
        services.Configure(configure);

        services.AddHttpClient<IYOLPClient, YOLPClient>();

        return services;
    }
}