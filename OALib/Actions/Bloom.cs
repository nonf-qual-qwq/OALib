using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class Bloom : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.Bloom;
    
    // 启用
    public bool Enabled = true;
    
    // 阈值
    public float Threshold = 50;
    
    // 强度
    public float Intensity = 100;
    
    // 颜色
    public string Color = "ffffff";
    
    // 时长
    public float Duration = 0;
    
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
             ["floor"] = Floor,
             ["eventType"] = EventType.ToString(),
             ["enabled"] = Enabled.ToString(),
             ["threshold"] = Threshold,
             ["intensity"] = Intensity,
             ["color"] = Color,
             ["duration"] = Duration,
             ["angleOffset"] = AngleOffset,
             ["ease"] = Ease.ToString(),
             ["eventTag"] = EventTag
            };
        return jObject;
    }
}