# Yahoo Developer API Client

Yahoo!デベロッパーネットワーク（特に YOLP: Yahoo! Open Local Platform）のローカルサーチ API を .NET から手軽に呼び出すための軽量クライアントライブラリです。  
ASP.NET Core などの DI コンテナと自然に統合できるよう Microsoft.Extensions.* に準拠し、リクエスト／レスポンスの型も用意しています。

---

## 特長

- **シンプルな YOLP クライアント**: `IYOLPClient` からローカルサーチ API を 1 メソッドで呼び出し。
- **強い型付け**: リクエストパラメーター（`LocalSearchRequest`）やレスポンス（`LocalSearchResult`）を C# のクラスで定義。
- **DI 連携**: `IServiceCollection.AddYOLPClient(...)` で .NET の依存性注入にそのまま登録可能。
- **HttpClient ラッパー**: `HttpAdapter` が例外メッセージを整形しつつ、汎用的な GET/POST/PUT/DELETE を提供。
- **テスト済み**: xUnit + Moq によるユニットテストを同梱。

---

## 対応環境

- .NET 9.0 以降
- 任意の OS（Windows / Linux / macOS）で動作する .NET SDK

---

## インストール

NuGet での公開はまだ行っていないため、以下いずれかの方法で利用してください。

1. **ソリューションに直接取り込む**  
   ```bash
   git submodule add https://github.com/<your-account>/YahooDeveloperApiClient.git
   dotnet add YourProject reference YahooDeveloperApiClient/YahooDeveloperApiClient.csproj
   ```
2. **自作ライブラリに組み込む**  
   `YahooDeveloperApiClient` プロジェクトをソリューションに追加し、参照設定を行います。

---

## 使い方

### 1. DI コンテナへ登録

```csharp
using YahooDeveloperApiClient.Configuration;

builder.Services.AddYOLPClient(opt =>
{
    opt.AppId = builder.Configuration["Yahoo:YOLP:AppId"];
});
```

`YOLPClientOptions.AppId` には Yahoo! デベロッパーネットワークで取得したアプリケーション ID を指定します。

### 2. クライアントを注入して呼び出し

```csharp
using YahooDeveloperApiClient.YOLP;
using YahooDeveloperApiClient.YOLP.Request;

public class LocalSearchService(IYOLPClient yolpClient, ILogger<LocalSearchService> logger)
{
    public async Task<IEnumerable<string>> SearchRamenAsync(double lat, double lon)
    {
        var request = new LocalSearchRequest
        {
            Query = "ラーメン",
            Lat = lat,
            Lon = lon,
            Dist = 2.0,
            Results = 10,
            Detail = YdfDetailLevel.Standard
        };

        var result = await yolpClient.GetLocalSearchResultAsync(request);
        return result.Feature?.Select(f => $"{f.Name} ({f.Property?.Address})") ?? Array.Empty<string>();
    }
}
```

### 3. 単体で使いたい場合

```csharp
var httpClient = new HttpClient();
var yolp = new YOLPClient(httpClient, appId: "<Your AppId>");
```

---

## 主なリクエストパラメーター

| プロパティ | 概要 |
| --- | --- |
| `Query` | 店舗名・業種などを含む検索キーワード（UTF-8） |
| `Lat` / `Lon` | 中心座標（世界測地系） |
| `Dist` | 探索距離（km、最大 20） |
| `Results` | 取得件数（1〜100） |
| `Sort` | `LocalSearchSort` で結果の並び替え |
| `Detail` | 取得レベル（`YdfDetailLevel` の `Simple`, `Standard`, `Full`） |
| `GenreCode` | YOLP 業種コード |
| `Coupon`, `Parking`, `CreditCard`, `Image` | 各種フィルタ条件 |

API の仕様詳細は [Yahoo!ローカルサーチ API ドキュメント](https://developer.yahoo.co.jp/webapi/map/openlocalplatform/v1/local.html) を参照してください。

---

## 利用上の注意・ポリシー

- 本 SDK は **非公式** です。Yahoo! JAPAN 提供の公式 SDK ではないため、利用時はその旨を周知してください。
- 利用にあたっては Yahoo! JAPAN の [デベロッパーネットワーク利用規約](https://developer.yahoo.co.jp/appendix/rules/) および各 API の個別規約に従う必要があります。
- アプリケーション ID（AppID）は個人・組織ごとに発行されるため、リポジトリやバイナリにハードコード・公開しないでください。
- レスポンスデータのキャッシュ、再配布、表示方法、レート制限、クレジット表記（「Powered by Yahoo! JAPAN」など）が求められるケースがあります。用途に応じて最新のドキュメントを確認してください。
- クレジット表示は、Yahoo!デベロッパーネットワークを利用したアプリケーションの **下部** に配置してください。サイトを持たないスマートデバイスアプリやスマートスピーカースキル等では、**ストアページの最下部** に表示する必要があります。
- API 呼び出しの失敗や制限超過に備えて、アプリ側でリトライやスロットリングを実装することを推奨します。

これらの制約に違反した場合は Yahoo! JAPAN から AppID の停止等の措置を受ける可能性があるため、必ず最新の規約を確認してください。

---

## テスト

```bash
dotnet test YahooDeveloperApiClient.sln
```

Moq を用いた HTTP レイヤーのモックテストや、例外メッセージの検証を実装しています。変更時はテストを追加し、すべてのテストが成功することを確認してください。

---

## 開発ガイドライン

- C# 12 / .NET 9 の最新スタイルを採用しています。`dotnet format` などでコードスタイルを維持してください。
- 追加する公開 API には XML ドキュメントコメントを付与してください。
- 例外メッセージは開発・運用時に調査しやすい情報（ステータスコード、レスポンス本文など）を含める方針です。

Pull Request 大歓迎です。Issue でアイデアやバグ報告をいただけると助かります。

---

## ライセンス

MIT License（`LICENSE` を参照）。
