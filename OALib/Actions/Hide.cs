using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Enum;

public class Hide : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Enum.EventType EventType = Enum.EventType.Hide;
    
    // 隐藏判定
    public bool HideJudgment = false;
    
    // 隐藏图标
    public bool HideTileIcon = false;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["hideJudgment"] = HideJudgment,
            ["hideTileIcon"] = HideTileIcon,
        };
        return jObject;
    }
}