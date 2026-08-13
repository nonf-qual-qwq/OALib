using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;
public class ScalePlanets : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetPlanetRotation;
    
    // 时长
    public float Duration = 1;
    
    // 目标星球
    public Lib.TargetPlanet TargetPlanet = Lib.TargetPlanet.FirePlanet;
    
    // 大小
    public float Scale = 100;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 事件标签
    public string EventTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["Floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["targetPlanet"] = TargetPlanet.ToString(),
            ["scale"] = Scale,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["eventTag"] = EventTag
        };
        return jObject;
    }

}