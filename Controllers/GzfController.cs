using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShenzhenLhgs.Database;
using ShenzhenLhgs.Models;

namespace ShenzhenLhgs.Controllers;

[ApiController]
[Route("/gzf")]
public class GzfController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public GzfController(
        AppDbContext appDbContext
    )
    {
        _appDbContext = appDbContext;
    }

    [HttpGet("search")]
    public async Task<RanksDto> Get([FromQuery] RankQuery query)
    {
        var gjfQueryable = _appDbContext.GzfRankings.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Shoulhzh))
        {
            gjfQueryable = gjfQueryable.Where(t => t.Shoulhzh.Contains(query.Shoulhzh.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(query.AreaName))
        {
            if (!Constants.Areas.TryGetValue(query.AreaName, out var area))
            {
                throw new ApplicationException("区域不存在");
            }

            gjfQueryable = gjfQueryable.Where(t => t.Area == area);
        }

        if (!string.IsNullOrWhiteSpace(query.Xingm))
        {
            gjfQueryable = gjfQueryable.Where(t => t.Xingm.Contains(query.Xingm.Trim()));
        }

        if (!string.IsNullOrWhiteSpace(query.Sfzh))
        {
            gjfQueryable = gjfQueryable.Where(t => t.Sfzh.StartsWith(query.Sfzh.Trim()));
        }

        var items = await gjfQueryable.OrderBy(t => t.Paix).Take(10).ToListAsync();

        return new RanksDto
        {
            Items = items
        };
    }

    [HttpGet("change-area-forecast")]
    public async Task<ChangeAreaForecastDto> ChangeAreaForecast([FromQuery] ChangeAreaForecastQuery query)
    {
        var item = await _appDbContext.GzfRankings.FirstOrDefaultAsync(t => t.Shoulhzh == query.Shoulhzh);
        if (item == null)
        {
            throw new ApplicationException("受理回执号不存在");
        }

        if (!Constants.Areas.TryGetValue(query.ToAreaName, out var area))
        {
            throw new ApplicationException("区域不存在");
        }

        var last = await _appDbContext.GzfRankings
            .AsQueryable()
            .Where(t => t.Area == area)
            .Where(t => t.Paix < item.Paix)
            .OrderByDescending(t => t.Paix)
            .FirstOrDefaultAsync();

        return new ChangeAreaForecastDto
        {
            Paix = item.Paix,
            AreaPaix = item.AreaPaix,
            RevisedAreaPaix = (last?.AreaPaix ?? 0) + 1
        };
    }

    [HttpGet("summary")]
    public async Task<SummaryDto> Summary()
    {
        var gjfQueryable = _appDbContext.GzfRankings.AsQueryable();
        var items = await gjfQueryable
            .GroupBy(t => t.Area)
            .Select(t => new
            {
                Area = t.Key,
                Count = t.Count(),
            })
            .OrderByDescending(t => t.Count)
            .ToListAsync();

        var result = items.ToDictionary(t => Constants.AreaNames[t.Area], t => t.Count);

        return new SummaryDto
        {
            Items = result
        };
    }
}