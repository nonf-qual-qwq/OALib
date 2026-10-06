using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Enum;

public class ScaleMargin : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Enum.EventType EventType = Enum.EventType.ScaleMargin;
    
    // 判定大小
    public float Scale = 100;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["scale"] = Scale,
        };
        return jObject;
    }
}