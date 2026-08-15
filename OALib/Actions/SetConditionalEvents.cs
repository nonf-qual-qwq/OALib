using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class SetConditionalEvents : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetConditionalEvents;
    
    // 完美标签
    public string PerfectTag = "";
    
    // 打击标签
    public string HitTag = "";
    
    // 稍快标签
    public string EarlyPerfectTag = "";

    // 稍慢标签
    public string LatePerfectTag = "";

    // 勉强标签
    public string BarelyTag = "";
    
    // 太快标签
    public string VeryEarlyTag = "";

    // 太慢标签
    public string VeryLateTag = "";

    // 错过标签
    public string MissTag = "";
    
    // 特别快标签
    public string TooEarlyTag = "";
    
    // 特别慢标签
    public string TooLateTag = "";
    
    // 丢拍标签
    public string LossTag = "";
    
    // 重启时标签
    public string OnCheckpointTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["perfectTag"] = PerfectTag,
            ["hitTag"] = HitTag,
            ["earlyPerfectTag"] = EarlyPerfectTag,
            ["latePerfectTag"] = LatePerfectTag,
            ["barelyTag"] = BarelyTag,
            ["veryEarlyTag"] = VeryEarlyTag,
            ["veryLateTag"] = VeryLateTag,
            ["missTag"] = MissTag,
            ["tooEarlyTag"] = TooEarlyTag,
            ["tooLateTag"] = TooLateTag,
            ["lossTag"] = LossTag,
            ["onCheckpointTag"] = OnCheckpointTag,
        };
        return jObject;
    }
}