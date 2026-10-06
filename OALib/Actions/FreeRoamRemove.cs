using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class FreeRoamRemove : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.FreeRoamRemove;
    
    // 位置偏移
    public float[] Position = [1, 0];
    
    // 要移除的区域
    public float[] Size = [1, 1];

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["position"] = JArray.FromObject(Position),
            ["size"] = JArray.FromObject(Size),
        };
        return jObject;
    }
}