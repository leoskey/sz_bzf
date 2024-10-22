namespace ShenzhenLhgs.Models;

public class RankQuery
{
    /// <summary>
    /// 受理回执号
    /// </summary>
    public string Shoulhzh { get; set; }

    /// <summary>
    /// 所属行政区
    /// </summary>
    public string AreaName { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string Xingm { get; set; }
    
    /// <summary>
    /// 身份证号前10位
    /// </summary>
    public string Sfzh { get; set; }
}