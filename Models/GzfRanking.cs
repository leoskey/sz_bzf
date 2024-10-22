using System.Text.Json.Serialization;

namespace ShenzhenLhgs.Models;

/// <summary>
/// 公租房
/// </summary>
public class GzfRanking
{
    [JsonPropertyName("area")]
    public string Area { get; set; }

    [JsonPropertyName("areaPaix")]
    public int AreaPaix { get; set; }

    [JsonPropertyName("batch")]
    public string Batch { get; set; }

    [JsonPropertyName("chengylx")]
    public string Chengylx { get; set; }

    [JsonPropertyName("createId")]
    public string CreateId { get; set; }

    [JsonPropertyName("createTime")]
    public string CreateTime { get; set; }

    [JsonPropertyName("createUser")]
    public string CreateUser { get; set; }

    [JsonPropertyName("dgsBatchId")]
    public string DgsBatchId { get; set; }

    [JsonPropertyName("gongszt")]
    public string Gongszt { get; set; }

    [JsonPropertyName("hujszq")]
    public string Hujszq { get; set; }

    [JsonPropertyName("hunyzk")]
    public string Hunyzk { get; set; }

    [JsonPropertyName("juzdszjd")]
    public string Juzdszjd { get; set; }

    [JsonPropertyName("juzdszq")]
    public string Juzdszq { get; set; }

    [JsonPropertyName("lhmcId")]
    public string LhmcId { get; set; }

    [JsonPropertyName("lianxdh")]
    public string Lianxdh { get; set; }

    [JsonPropertyName("lunhlb")]
    public string Lunhlb { get; set; }

    [JsonPropertyName("num")]
    public string Num { get; set; }

    [JsonPropertyName("numpaix")]
    public int? Numpaix { get; set; }

    [JsonPropertyName("outlhFlag")]
    public string OutlhFlag { get; set; }

    [JsonPropertyName("outTime")]
    public string OutTime { get; set; }

    [JsonPropertyName("paix")]
    public int Paix { get; set; }

    [JsonPropertyName("personType")]
    public string PersonType { get; set; }

    [JsonPropertyName("quaDate")]
    public string QuaDate { get; set; }

    [JsonPropertyName("quaExplain")]
    public string QuaExplain { get; set; }

    [JsonPropertyName("qyybzj")]
    public string Qyybzj { get; set; }

    [JsonPropertyName("remark")]
    public string Remark { get; set; }

    [JsonPropertyName("rgqk")]
    public string Rgqk { get; set; }

    [JsonPropertyName("rucsj")]
    public string Rucsj { get; set; }

    [JsonPropertyName("ruhsj")]
    public string Ruhsj { get; set; }

    [JsonPropertyName("rzqk")]
    public string Rzqk { get; set; }

    [JsonPropertyName("seqNo")]
    public string SeqNo { get; set; }

    [JsonPropertyName("sfzh")]
    public string Sfzh { get; set; }

    [JsonPropertyName("shenfzh")]
    public string Shenfzh { get; set; }

    [JsonPropertyName("shenqlb")]
    public string Shenqlb { get; set; }

    [JsonPropertyName("shifcj")]
    public string Shifcj { get; set; }

    [JsonPropertyName("shifrc")]
    public string Shifrc { get; set; }

    [JsonPropertyName("shifzsqr")]
    public string Shifzsqr { get; set; }

    [JsonPropertyName("shouccbsj")]
    public string Shouccbsj { get; set; }

    [JsonPropertyName("shouccbsjAj")]
    public string ShouccbsjAj { get; set; }

    [JsonPropertyName("shouccbsjGz")]
    public string ShouccbsjGz { get; set; }

    [JsonPropertyName("shoulhzh")]
    public string Shoulhzh { get; set; }

    [JsonPropertyName("sjqrly")]
    public string Sjqrly { get; set; }

    [JsonPropertyName("sjqrsj")]
    public string Sjqrsj { get; set; }

    [JsonPropertyName("slbahzId")]
    public string SlbahzId { get; set; }

    [JsonPropertyName("sqbId")]
    public string SqbId { get; set; }

    [JsonPropertyName("sqcyxxbId")]
    public string SqcyxxbId { get; set; }

    [JsonPropertyName("updateId")]
    public string UpdateId { get; set; }

    [JsonPropertyName("updateTime")]
    public string UpdateTime { get; set; }

    [JsonPropertyName("updateUser")]
    public string UpdateUser { get; set; }

    [JsonPropertyName("waitFlag")]
    public string WaitFlag { get; set; }

    [JsonPropertyName("waitTpye")]
    public string WaitTpye { get; set; }

    [JsonPropertyName("waitTpyeCode")]
    public string WaitTpyeCode { get; set; }

    [JsonPropertyName("xingm")]
    public string Xingm { get; set; }
}