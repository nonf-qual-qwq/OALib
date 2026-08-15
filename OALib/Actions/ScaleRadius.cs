using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;
public class ScaleRadius : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.ScaleRadius;
    
    // 大小
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