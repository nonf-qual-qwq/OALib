using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class SetObject : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetParticle;
    
    // 时长
    public float Duration = 1;
    
    // 标签
    public string Tag = "";
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 事件标签
    public string EventTag = "";
    
    // 星球颜色
    public string? PlanetColor;
    
    // 星球轨迹颜色
    public string? PlanetTailColor;
    
    // 轨道角度
    public float? TrackAngle;
    
    // 轨道颜色类型
    public Lib.TrackColorType? TrackColorType;
    
    // 轨道主色调
    public string? TrackColor;
    
    // 轨道副色调
    public string? SecondaryTrackColor;
    
    // 轨道颜色动画时长
    public float? TrackColorAnimDuration;
    
    // 轨道透明度
    public float? TrackOpacity;
    
    // 轨道风格
    public Lib.TrackStyle? TrackStyle;

    // 轨道图标
    public Lib.TrackIcon? TrackIcon;

    // 轨道图标角度
    public float? TrackIconAngle;
    
    // 轨道图标反转
    public bool? TrackIconFlipped;
    
    // 轨道图标红色漩涡
    public bool? TrackRedSwirl;
    
    // 轨道灰色设置速度图标
    public bool? TrackGraySetSpeedIcon;
    
    // 允许轨道发光
    public bool? TrackGlowEnabled;
    
    // 轨道发光颜色
    public string? TrackGlowColor;

    // 轨道图标描边
    public bool? TrackIconOutlines;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["tag"] = Tag,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["eventTag"] = EventTag,
        };

        if (PlanetColor != null)
        {
            jObject["planetColor"] = PlanetColor;
        }

        if (PlanetTailColor != null)
        {
            jObject["planetTailColor"] = PlanetTailColor;
        }

        if (TrackAngle != null)
        {
            jObject["trackAngle"] = TrackAngle;
        }

        if (TrackColorType != null)
        {
            jObject["trackColorType"] = TrackColorType.ToString();
        }

        if (TrackColor != null)
        {
            jObject["trackColor"] = TrackColor;
        }

        if (SecondaryTrackColor != null)
        {
            jObject["secondaryTrackColor"] = SecondaryTrackColor;
        }

        if (TrackColorAnimDuration != null)
        {
            jObject["trackColorAnimDuration"] = TrackColorAnimDuration;
        }

        if (TrackOpacity != null)
        {
            jObject["trackOpacity"] = TrackOpacity;
        }

        if (TrackStyle != null)
        {
            jObject["trackStyle"] = TrackStyle.ToString();
        }

        if (TrackIcon != null)
        {
            jObject["trackIcon"] = TrackIcon.ToString();
        }

        if (TrackIconAngle != null)
        {
            jObject["trackIconAngle"] = TrackIconAngle;
        }

        if (TrackIconFlipped != null)
        {
            jObject["trackIconFlipped"] = TrackIconFlipped;
        }

        if (TrackRedSwirl != null)
        {
            jObject["trackRedSwirl"] = TrackRedSwirl;
        }

        if (TrackGraySetSpeedIcon != null)
        {
            jObject["trackGraySetSpeedIcon"] = TrackGraySetSpeedIcon;
        }

        if (TrackGlowEnabled != null)
        {
            jObject["trackGlowEnabled"] = TrackGlowEnabled;
        }

        if (TrackGlowColor != null)
        {
            jObject["trackGlowColor"] = TrackGlowColor;
        }

        if (TrackIconOutlines != null)
        {
            jObject["trackIconOutlines"] = TrackIconOutlines;
        }

        return jObject;
    }
}