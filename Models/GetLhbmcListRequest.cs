using System.Text.Json.Serialization;

namespace ShenzhenLhgs.Models;

public class GetLhbmcListRequest
{
    [JsonPropertyName("page")]
    public long Page { get; set; }

    [JsonPropertyName("pageNumber")]
    public long PageNumber { get; set; }

    [JsonPropertyName("pageSize")]
    public long PageSize { get; set; }

    [JsonPropertyName("waittype")]
    public string WaitType { get; set; }
}