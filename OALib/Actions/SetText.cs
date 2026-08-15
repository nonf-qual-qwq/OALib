using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class SetText : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetText;
    
    // 文本
    public string DecText = "";
    
    // 标签
    public string Tag = "";
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 事件标签
    public string EventTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] =  EventType.ToString(),
            ["decText"] = DecText,
            ["tag"] = Tag,
            ["angleOffset"] = AngleOffset,
            ["eventTag"] = EventTag,
        };
        return jObject;
    }
}