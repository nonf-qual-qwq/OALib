using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;
public class RecolorTrack : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.RecolorTrack;
    
    // 效果起始方块数
    public int StartTileNumber = 0;
    
    // 效果起始方块对应
    public Lib.EffectTileType StartTileType = Lib.EffectTileType.ThisTile;
    
    // 效果结束方块数
    public int EndTileNumber = 0;
    
    // 效果结束方块对应
    public Lib.EffectTileType EndTileType = Lib.EffectTileType.ThisTile;
    
    // 间隙长度
    public int GapLength = 0;
    
    // 时长
    public float Duration = 0;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 事件标签
    public string EventTag = "";
    
    // 轨道颜色类型
    public Lib.TrackColorType? TrackColorType = Lib.TrackColorType.Single;
    
    // 轨道主色调
    public string? TrackColor;
    
    // 轨道副色调
    public string? SecondaryTrackColor;
    
    // 轨道颜色动画时长
    public float? TrackColorAnimDuration;
    
    // 轨道颜色脉冲
    public bool? TrackColorPulse;
    
    // 轨道颜色长度
    public int? TrackPulseLength;
    
    // 轨道风格
    public Lib.TrackStyle? TrackStyle;
    
    // 轨道图片
    public string? TrackTexture;
    
    // 辉度
    public int? TrackGlowIntensity;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["startTile"] = JArray.FromObject(new Object[] {StartTileNumber, StartTileType}),
            ["endTile"] = JArray.FromObject(new Object[] {EndTileNumber, EndTileType}),
            ["gapLength"] = GapLength,
            ["duration"] = Duration,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["eventTag"] = EventTag,
        };

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

        if (TrackColorPulse != null)
        {
            jObject["trackColorPulse"] = TrackColorPulse;
        }

        if (TrackPulseLength != null)
        {
            jObject["trackPulseLength"] = TrackPulseLength;
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

        return jObject;
    }


}