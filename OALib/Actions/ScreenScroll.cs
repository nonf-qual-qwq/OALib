using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class ScreenScroll : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetFrameRate;
    
    // 卷屏速度
    public float[] Scroll = { 0, 0 };
    
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
            ["scroll"] = JArray.FromObject(Scroll),
            ["angleOffset"] = AngleOffset,
            ["eventTag"] = EventTag
        };
        return jObject;
    }
}