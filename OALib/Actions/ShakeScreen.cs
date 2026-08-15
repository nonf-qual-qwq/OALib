using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class ShakeScreen : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.ShakeScreen;
    
    // 时长
    public float Duration = 1;
    
    // 强度
    public float Strength = 100;
    
    // 速度
    public float Intensity = 100;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 淡出
    public bool FadeOut = true;
    
    // 事件标签
    public string EventTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["strength"] = Strength,
            ["intensity"] = Intensity,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["fadeOut"] = FadeOut,
            ["eventTag"] = EventTag
        };
        return jObject;
    }
}