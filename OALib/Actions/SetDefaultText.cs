using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class SetDefaultText : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetDefaultText;
    
    // 时长
    public float Duration = 1;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 事件标签
    public string EventTag = "";
    
    // 默认文本颜色
    public string? DefaultTextColor;
    
    // 默认文本阴影颜色
    public string? DefaultTextShadowColor;
    
    // 关卡标题位置
    public float?[] LevelTitlePosition = new float?[2] { null, null };
    
    // 关卡标题文本
    public string? LevelTitleText;
    
    // 祝贺文本
    public string? CongratsText;
    
    // 无暇文本
    public string? PerfectText;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["eventTag"] = EventTag,
            
        };

        if (DefaultTextColor != null)
        {
            jObject["defaultTextColor"] = DefaultTextColor;
        }

        if (DefaultTextShadowColor != null)
        {
            jObject["defaultTextShadowColor"] = DefaultTextShadowColor;
        }

        if (LevelTitlePosition[0] != null || LevelTitlePosition[1] != null)
        {
            jObject["levelTitlePosition"] = JArray.FromObject(LevelTitlePosition);
        }

        if (LevelTitleText != null)
        {
            jObject["levelTitleText"] = JArray.FromObject(LevelTitleText);
        }

        if (CongratsText != null)
        {
            jObject["congratsText"] = JArray.FromObject(CongratsText);
        }

        if (PerfectText != null)
        {
            jObject["perfectText"] = JArray.FromObject(PerfectText);
        }

        return jObject;
    }
}