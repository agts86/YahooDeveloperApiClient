using System.Net;
using Moq;
using Moq.Protected;
using YahooDeveloperApiClient.YOLP;
using YahooDeveloperApiClient.YOLP.Request;

namespace YahooDeveloperApiClientTest.YOLP;

public class YOLPClientTests
{
    [Fact]
    public async Task PostReplyAsync_SendsCorrectRequest()
    {
        // Arrange
        var handlerMock = new Mock<HttpMessageHandler>();
        HttpRequestMessage capturedRequest = null;
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>((req, ct) => capturedRequest = req)
            .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("{}") });
        var httpClient = new HttpClient(handlerMock.Object);
        var client = new YOLPClient(httpClient, "dummyAppId");
        var dto = new LocalSearchRequest();

        // Act
        await client.GetLocalSearchResultAsync(dto);

        // Assert
        Assert.NotNull(capturedRequest);
        Assert.Equal(HttpMethod.Get, capturedRequest.Method);
        Assert.Equal("https://map.yahooapis.jp/search/local/V1/localSearch?appid=dummyAppId&output=json", capturedRequest.RequestUri.ToString());
    }
}

