using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class Hold : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.Hold;
    
    // 时长
    public float Duration = 0;
    
    // 旅行距离
    public int DistanceMultiplier = 100;
    
    // 收尾动画
    public bool LandingAnimation = false;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["distanceMultiplier"] = DistanceMultiplier,
            ["landingAnimation"] = LandingAnimation,
        };
        return jObject;
    }
}