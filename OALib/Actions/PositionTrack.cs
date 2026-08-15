using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class PositionTrack : JObject
{ 
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.PositionTrack;
    
    // 关联方块数
    public int RelativeToTileNumber = 0;
    
    // 关联方块对应
    public Lib.EffectTileType RelativeToTileType = Lib.EffectTileType.ThisTile;
    
    // 仅改变此方块
    public bool JustThisTile = false;
    
    // 仅限编辑器
    public bool EditorOnly = false;
    
    // 位置
    public float?[] PositionOffset = new float?[2] { null, null };
    
    // 旋转
    public float? RotationOffset;
    
    // 大小
    public float?[] Scale = new float?[2] { null, null };
    
    // 轨道透明度
    public float? Opacity;
    
    // 粘性方块
    public bool? StickToFloors;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["relativeTo"] = JArray.FromObject(new Object[] {RelativeToTileNumber, RelativeToTileType}),
            ["justThisTile"] = JustThisTile,
            ["editorOnly"] = EditorOnly,
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

        if (StickToFloors != null)
        {
            jObject["stickToFloors"] = JArray.FromObject(StickToFloors);
        }

        return jObject;

    }
}