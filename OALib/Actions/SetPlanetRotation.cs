using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class SetPlanetRotation : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetPlanetRotation;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 缓速部分
    public int EaseParts = 1;
    
    // 缓速部分行为
    public Lib.EasePartBehavior EasePartBehavior = Lib.EasePartBehavior.Mirror;

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