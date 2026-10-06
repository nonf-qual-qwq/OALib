using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Enum;
public class EditorComment : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Enum.EventType EventType = Enum.EventType.CustomBackground;
    
    // 评论
    public string Comment = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["comment"] = Comment,
        };
        return jObject;
    }
}