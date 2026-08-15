using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class Flash : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.MoveDecorations;
    
    // 时长
    public float Duration = 1;
    
    // 平面
    public Lib.Plane Plane = Lib.Plane.Background;
    
    // 起始颜色
    public string StartColor = "ffffff";
    
    // 起始透明度
    public float StartOpacity = 100;
    
    // 结束颜色
    public string EndColor = "ffffff";
    
    // 结束透明度
    public float EndOpacity = 100;
    
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
            ["duration"] = Duration,
            ["plane"] = Plane.ToString(),
            ["startColor"] = StartColor,
            ["endColor"] = EndColor,
            ["startOpacity"] = StartOpacity,
            ["endOpacity"] = EndOpacity,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["eventTag"] = EventTag,
        };
        return jObject;
    }
}