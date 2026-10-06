using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class FreeRoamTwirl : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.FreeRoamTwirl;
    
    // 位置偏移
    public float[] Position = [1, 0];
    
    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["position"] = JArray.FromObject(Position),
        };
        return jObject;
    }
}