using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class MoveCamera : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.MoveCamera;
    
    // 时长
    public float Duration = 1;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 事件标签
    public string EventTag = "";
    
    // 关联于
    public Lib.RelativeTo? RelativeTo = Lib.RelativeTo.Player;
    
    // 位置
    public float?[] PositionOffset = new float?[2] { null, null };
    
    // 旋转
    public float? RotationOffset;
    
    // 缩放
    public float? Zoom;

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

        if (RelativeTo != null)
        {
            jObject["relativeTo"] = RelativeTo.ToString();
        }

        if (Zoom != null)
        {
            jObject["zoom"] = Zoom;
        }

        if (PositionOffset[0] != null || PositionOffset[1] != null)
        {
            jObject["positionOffset"] = JArray.FromObject(PositionOffset);
        }

        if (RotationOffset != null)
        {
            jObject["rotationOffset"] = RotationOffset;
        }

        return jObject;
    }
}