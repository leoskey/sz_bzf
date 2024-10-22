using System.ComponentModel.DataAnnotations;

namespace ShenzhenLhgs.Models;

public class ChangeAreaForecastQuery
{
    /// <summary>
    /// 受理回执号
    /// </summary>
    [Required]
    public string Shoulhzh { get; set; }

    /// <summary>
    /// 所属行政区
    /// </summary>
    [Required]
    public string ToAreaName { get; set; }
}