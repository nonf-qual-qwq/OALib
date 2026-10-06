using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Enum;

public class SetPlanetRotation : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Enum.EventType EventType = Enum.EventType.SetPlanetRotation;
    
    // 缓速
    public Enum.Ease Ease = Enum.Ease.Linear;
    
    // 缓速部分
    public int EaseParts = 1;
    
    // 缓速部分行为
    public Enum.EasePartBehavior EasePartBehavior = Enum.EasePartBehavior.Mirror;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["ease"] = Ease.ToString(),
            ["easeParts"] = EaseParts,
            ["easePartBehavior"] = EasePartBehavior.ToString(),
        };
        
        return jObject;
    }
}