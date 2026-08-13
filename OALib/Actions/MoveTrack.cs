using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class MoveTrack : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.MoveTrack;
    
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
    
    // 仅限最大特效
    public bool MaxVfxOnly = false;
    
    // 事件标签
    public string EventTag = "";
    
    // 位置
    public float?[] PositionOffset = new float?[2] { null, null };
    
    // 旋转
    public float? RotationOffset;
    
    // 大小
    public float?[] Scale = new float?[2] { null, null };
    
    // 轨道透明度
    public float? Opacity;
    
    
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
            ["maxVfxOnly"] = MaxVfxOnly,
            ["eventTag"] = EventTag,
        };

        if (PositionOffset[0] != null || PositionOffset[1] != null)
        {
            jObject["positionOffset"] = JArray.FromObject(PositionOffset);
        }

        if (RotationOffset != null)
        {
            jObject["rotationOffset"] = JArray.FromObject(RotationOffset);
        }

        if (Scale[0] != null || Scale[1] != null)
        {
            jObject["scale"] = JArray.FromObject(Scale);
        }

        if (Opacity != null)
        {
            jObject["opacity"] = JArray.FromObject(Opacity);
        }

        return jObject;
    }
}