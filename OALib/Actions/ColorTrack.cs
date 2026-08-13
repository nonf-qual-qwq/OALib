using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class ColorTrack : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.ColorTrack;
    
    // 轨道副色调
    public string SecondaryTrackColor = "ffffff";
    
    // 轨道颜色动画时长
    public float TrackColorAnimDuration = 2;
    
    // 轨道颜色脉冲
    public bool TrackColorPulse = false;
    
    // 轨道颜色长度
    public int TrackPulseLength = 10;
    
    // 仅改变该方块
    public bool JustThisTile = false;
    
    // 轨道颜色类型
    public Lib.TrackColorType? TrackColorType;
    
    // 轨道颜色
    public string? TrackColor;
    
    // 轨道风格
    public Lib.TrackStyle? TrackStyle;
    
    // 轨道图片
    public string? TrackTexture;
    
    // 辉度
    public int? TrackGlowIntensity;
    
    // 方块图标描边
    public bool? FloorIconOutlines;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["secondaryTrackColor"] = SecondaryTrackColor,
            ["trackColorAnimDuration"] = TrackColorAnimDuration,
            ["trackColorPulse"] = TrackColorPulse,
            ["trackPulseLength"] = TrackPulseLength,
            ["justThisTile"] = JustThisTile,
        };

        if (TrackColorType != null)
        {
            jObject["trackColorType"] = TrackColorType.ToString();
        }

        if (TrackColor != null)
        {
            jObject["trackColor"] = TrackColor;
        }

        if (TrackStyle != null)
        {
            jObject["trackStyle"] = TrackStyle.ToString();
        }

        if (TrackTexture != null)
        {
            jObject["trackTexture"] = TrackTexture;
        }

        if (TrackGlowIntensity != null)
        {
            jObject["trackGlowIntensity"] = TrackGlowIntensity;
        }

        if (FloorIconOutlines != null)
        {
            jObject["floorIconOutlines"] = FloorIconOutlines;
        }

        return jObject;
    }

}
