using Microsoft.EntityFrameworkCore;
using ShenzhenLhgs.Database;
using ShenzhenLhgs.Models;

namespace ShenzhenLhgs.BackgroundWorkers;

public class PullAjfDataWorker : BackgroundService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PullAjfDataWorker> _logger;

    public PullAjfDataWorker(
        IHttpClientFactory httpClientFactory,
        IServiceProvider serviceProvider,
        ILogger<PullAjfDataWorker> logger
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

        var last = await appDbContext.AjfRankings.OrderByDescending(t => t.Paix)
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
                        "04b038f374c866a528017f83b4e4de55d10faa3ae357381c01d3bd2d21d2c106419e3e4baa26aa5d07d0e42fae91170fd4d020d794e260da2d23f8e6eac54fa489caebbf111b285e4c7c638d016763485b4bf23695bd05f8a5fc7677f27ccf1c21f054919c"
                }, cancellationToken: stoppingToken);
            var response =
                await responseMessage.Content.ReadFromJsonAsync<GetLhbmcListResponse<AjfRanking>>(
                    cancellationToken: stoppingToken);
            if (response is { Data: not null } && response.Data.List.Count != 0)
            {
                await appDbContext.AjfRankings.AddRangeAsync(response.Data.List, stoppingToken);
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