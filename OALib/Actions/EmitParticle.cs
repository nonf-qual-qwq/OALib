using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class EmitParticle : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.EmitParticle;
    
    // 标签
    public string Tag = "";
    
    // 数量
    public int Count = 10;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 事件标签
    public string EventTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["tag"] = Tag,
            ["count"] = Count,
            ["angleOffset"] = AngleOffset,
            ["eventTag"] = EventTag,
        };
        return jObject;
    }
}