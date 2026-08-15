using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class HallOfMirrors : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.HallOfMirrors;
    
    // 启动
    public bool Enabled = true;
    
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
            ["enabled"] = Enabled,
            ["angleOffset"] = AngleOffset,
            ["eventTag"] = EventTag,
        };
        return jObject;
    }
}