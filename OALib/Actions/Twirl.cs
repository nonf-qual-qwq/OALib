using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class Twirl : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.Twirl;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
        };
        return jObject;
    }
}