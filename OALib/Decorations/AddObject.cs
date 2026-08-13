using Newtonsoft.Json.Linq;

namespace OALib.Decorations;

using Lib;

public class AddObject : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.AddObject;
    
    // 对象类型
    public Lib.ObjectType ObjectType = Lib.ObjectType.Floor;

    // 复活泡泡出现起始偏移
    public int BubbleAppearStartOffset = 8;

    // 复活泡泡出现结束偏移
    public int BubbleAppearEndOffset = 2;
    
    // 复活泡泡消失偏移
    public int BubbleDisappearOffset = 4;

    // 复活泡泡生成偏移
    public int BubbleSpawnOffset = 3;

    // 标签
    public string Tag = "";
    
    // 星球颜色类型
    public Lib.PlanetColorType PlanetColorType = Lib.PlanetColorType.DefaultRed;

    // 星球颜色
    public string PlanetColor = "ff0000";
    
    // 星球轨迹颜色
    public string PlanetTailColor = "ff0000";
    
    // 规则类型
    public Lib.TrackType TrackType =  Lib.TrackType.Normal;
    
    // 轨道角度
    public float TrackAngle = 180;

    // 轨道颜色类型
    public Lib.TrackColorType TrackColorType = Lib.TrackColorType.Single;
    
    // 轨道主色调
    public string TrackColor = "debb7bff";
    
    // 轨道副色调
    public string SecondaryTrackColor = "ffffff";
    
    // 轨道颜色动画时长
    public float TrackColorAnimDuration = 2;
    
    // 轨道透明度
    public float TrackOpacity = 100;
    
    // 轨道风格
    public Lib.TrackStyle TrackStyle = Lib.TrackStyle.Standard;

    // 轨道图标
    public Lib.TrackIcon TrackIcon = Lib.TrackIcon.None;

    // 轨道图标角度
    public float TrackIconAngle = 0;
    
    // 轨道图标反转
    public bool TrackIconFlipped = false;
    
    // 轨道图标红色漩涡
    public bool TrackRedSwirl = false;
    
    // 轨道灰色设置速度图标
    public bool TrackGraySetSpeedIcon = false;
    
    // 设置速度图标bpm
    public float TrackSetSpeedIconBpm = 100;
    
    // 允许轨道发光
    public bool TrackGlowEnabled = false; 
    
    // 轨道发光颜色
    public string TrackGlowColor = "ffffff";

    // 轨道图标描边
    public bool TrackIconOutlines = false;

    // 位置
    public float[] Position = { 0, 0 };  
    
    // 相对于
    public Lib.RelativeTo RelativeTo = Lib.RelativeTo.Tile;
    
    // 轴心偏移
    public float[] PivotOffset = { 0, 0 };
    
    // 旋转
    public float Rotation = 0;
    
    // 锁定旋转
    public bool LockRotation = false;
    
    // 大小
    public float[] Scale = { 100, 100 };
    
    // 锁定大小
    public bool LockScale = false;

    // 深度
    public int Depth = -1;
    
    // 同步地板深度
    public bool SyncFloorDepth = false;
    
    // 平行
    public float[] Parallax = { 0, 0 };
    
    // 视觉偏移
    public float[] ParallaxOffset =  { 0, 0 };

    public JObject Create()
    {
        JObject jObject = new JObject
        {
            ["eventType"] = EventType.ToString(),
            ["floor"] = Floor,
            ["objectType"] = ObjectType.ToString(),
            ["bubbleAppearStartOffset"] = BubbleAppearStartOffset,
            ["bubbleAppearEndOffset"] = BubbleAppearEndOffset,
            ["bubbleDisappearOffset"] = BubbleDisappearOffset,
            ["bubbleSpawnOffset"] = BubbleSpawnOffset,
            ["tag"] = Tag,
            ["planetColorType"] = PlanetColorType.ToString(),
            ["planetColor"] = PlanetColor,
            ["planetTailColor"] = PlanetTailColor,
            ["trackType"] = TrackType.ToString(),
            ["trackAngle"] = TrackAngle,
            ["trackColorType"] = TrackColorType.ToString(),
            ["trackColor"] = TrackColor,
            ["secondaryTrackColor"] = SecondaryTrackColor,
            ["trackColorAnimDuration"] = TrackColorAnimDuration,
            ["trackOpacity"] = TrackOpacity,
            ["trackStyle"] = TrackStyle.ToString(),
            ["trackIcon"] = TrackIcon.ToString(),
            ["trackIconAngle"] = TrackIconAngle,
            ["trackIconFlipped"] = TrackIconFlipped,
            ["trackRedSwirl"] = TrackRedSwirl,
            ["trackGraySetSpeedIcon"] = TrackGraySetSpeedIcon,
            ["trackSetSpeedIconBpm"] = TrackSetSpeedIconBpm,
            ["trackGlowEnabled"] = TrackGlowEnabled,
            ["trackGlowColor"] = TrackGlowColor,
            ["trackIconOutlines"] = TrackIconOutlines,
            ["position"] = JArray.FromObject(Position),
            ["relativeTo"] = RelativeTo.ToString(),
            ["pivotOffset"] = JArray.FromObject(PivotOffset),
            ["rotation"] = Rotation,
            ["lockRotation"] = LockRotation,
            ["scale"] = JArray.FromObject(Scale),
            ["lockScale"] = LockScale,
            ["depth"] = Depth,
            ["syncFloorDepth"] = SyncFloorDepth,
            ["parallax"] = JArray.FromObject(Parallax),
            ["parallaxOffset"] = JArray.FromObject(ParallaxOffset)
        };

        return jObject;
    }

}