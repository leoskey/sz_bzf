using System.Text.Json.Serialization;

namespace ShenzhenLhgs.Models;

public class GetLhbmcListResponse<TEntity>
{
    [JsonPropertyName("code")]
    public long Code { get; set; }

    [JsonPropertyName("data")]
    public GetLhbmcListResponseData<TEntity> Data { get; set; }

    [JsonPropertyName("extra")]
    public string Extra { get; set; }

    [JsonPropertyName("isError")]
    public bool IsError { get; set; }

    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("msg")]
    public string Msg { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }
}