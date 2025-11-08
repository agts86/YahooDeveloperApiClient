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

    [Fact]
    public async Task GetGeoCoderResultAsync_SendsCorrectRequest()
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
        var request = new GeoCoderRequest();

        // Act
        await client.GetGeoCoderResultAsync(request);

        // Assert
        Assert.NotNull(capturedRequest);
        Assert.Equal(HttpMethod.Get, capturedRequest.Method);
        Assert.Equal("https://map.yahooapis.jp/geocode/V1/geoCoder?appid=dummyAppId&output=json", capturedRequest.RequestUri.ToString());
    }

    [Fact]
    public async Task GetReverseGeoCoderResultAsync_SendsCorrectRequest()
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
        var request = new ReverseGeoCoderRequest { Lat = 35.0, Lon = 139.0 };

        // Act
        await client.GetReverseGeoCoderResultAsync(request);

        // Assert
        Assert.NotNull(capturedRequest);
        Assert.Equal(HttpMethod.Get, capturedRequest.Method);
        Assert.Equal("https://map.yahooapis.jp/geoapi/V1/reverseGeoCoder?appid=dummyAppId&output=json&lat=35&lon=139", capturedRequest.RequestUri.ToString());
    }
}
