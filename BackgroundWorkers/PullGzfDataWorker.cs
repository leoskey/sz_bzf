using Microsoft.EntityFrameworkCore;
using ShenzhenLhgs.Database;
using ShenzhenLhgs.Models;

namespace ShenzhenLhgs.BackgroundWorkers;

public class PullGzfDataWorker : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PullGzfDataWorker> _logger;

    public PullGzfDataWorker(
        IHttpClientFactory httpClientFactory,
        IServiceProvider serviceProvider,
        ILogger<PullGzfDataWorker> logger
    )
    {
        _httpClientFactory = httpClientFactory;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var serviceScope = _serviceProvider.CreateScope();
        var appDbContext = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        var last = await appDbContext.GzfRankings.OrderByDescending(t => t.Paix)
            .FirstOrDefaultAsync(cancellationToken: stoppingToken);
        var startIndex = last?.Paix / 100 + 1 ?? 1L;

        var httpClient = _httpClientFactory.CreateClient();

        while (true)
        {
            _logger.LogInformation("current page is {Page}", startIndex);
            var responseMessage = await httpClient.PostAsJsonAsync("https://zjj.sz.gov.cn/zfxx/bzflh/lhmc/getLhmcList",
                new GetLhbmcListRequest
                {
                    Page = startIndex,
                    PageNumber = startIndex,
                    PageSize = 100,
                    WaitType =
                        "0407606cc10418c84de07f356f9a1f073825ab80c2228dccf01abd31c71e6cf0e631521a309fdb15556c5f59d094d36de20646e928e7b2944bd7c1f4f939383bff9e4bded14894353239d8cdf4277d1b4b2f45b3f8a1a8e1a36706eaab04ce6c7e02513998"
                }, cancellationToken: stoppingToken);
            var response =
                await responseMessage.Content.ReadFromJsonAsync<GetLhbmcListResponse<GzfRanking>>(
                    cancellationToken: stoppingToken);
            if (response is { Data: not null } && response.Data.List.Count != 0)
            {
                await appDbContext.GzfRankings.AddRangeAsync(response.Data.List, stoppingToken);
                await appDbContext.SaveChangesAsync(stoppingToken);
            }

            if (response.Data is not { HasNextPage: true })
            {
                _logger.LogInformation("task is over, last page is {Page}", startIndex);
                break;
            }

            startIndex = response.Data.NextPage;
            await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
        }
    }
}