using System.Text.Json.Serialization;

namespace ShenzhenLhgs.Models;

public class GetLhbmcListResponseData<TEntity>
{
    [JsonPropertyName("endRow")]
    public long EndRow { get; set; }

    [JsonPropertyName("firstPage")]
    public long FirstPage { get; set; }

    [JsonPropertyName("hasNextPage")]
    public bool HasNextPage { get; set; }

    [JsonPropertyName("hasPreviousPage")]
    public bool HasPreviousPage { get; set; }

    [JsonPropertyName("isFirstPage")]
    public bool IsFirstPage { get; set; }

    [JsonPropertyName("isLastPage")]
    public bool IsLastPage { get; set; }

    [JsonPropertyName("lastPage")]
    public long LastPage { get; set; }

    [JsonPropertyName("list")]
    public List<TEntity> List { get; set; }

    [JsonPropertyName("navigateFirstPage")]
    public long NavigateFirstPage { get; set; }

    [JsonPropertyName("navigateLastPage")]
    public long NavigateLastPage { get; set; }

    [JsonPropertyName("navigatepageNums")]
    public long[] NavigatepageNums { get; set; }

    [JsonPropertyName("navigatePages")]
    public long NavigatePages { get; set; }

    [JsonPropertyName("nextPage")]
    public long NextPage { get; set; }

    [JsonPropertyName("pageNum")]
    public long PageNum { get; set; }

    [JsonPropertyName("pages")]
    public long Pages { get; set; }

    [JsonPropertyName("pageSize")]
    public long PageSize { get; set; }

    [JsonPropertyName("prePage")]
    public long PrePage { get; set; }

    [JsonPropertyName("size")]
    public long Size { get; set; }

    [JsonPropertyName("startRow")]
    public long StartRow { get; set; }

    [JsonPropertyName("total")]
    public string Total { get; set; }
}