using Newtonsoft.Json.Linq;

namespace OALib.Decorations;

using Lib;

public class AddDecoration : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.AddObject;
    
    // 图片
    public string DecorationImage = "";
    
    // 标签
    public string Tag = "";
    
    // 位置
    public float[] Position = { 0, 0 };  
    
    // 相对于
    public Lib.RelativeTo RelativeTo = Lib.RelativeTo.Tile;
    
    // 依附地板
    public bool StickToFloor =  false;
    
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

    // 平铺装饰
    public float[] Tile = { 0, 0 };
    
    // 颜色
    public string TrackColor = "ffffff";
    
    // 透明度
    public float Opacity = 100;
    
    // 深度
    public int Depth = -1;
    
    // 同步地板深度
    public bool SyncFloorDepth = false;
    
    // 平行
    public float[] Parallax = { 0, 0 };
    
    // 视觉偏移
    public float[] ParallaxOffset =  { 0, 0 };
    
    // 图像平滑
    public bool ImageSmoothing = true;
    
    // 混合模式
    public Lib.BlendMode BlendMode = Lib.BlendMode.None;
    
    // 遮罩类型
    public Lib.MaskingType MaskingType =  Lib.MaskingType.None;
    
    // 遮罩目标
    public string MaskingTarget = "";
    
    // 使用遮罩深度
    public bool UseMaskingDepth = false;
    
    // 遮罩起始深度
    public int MaskingFrontDepth = -1;
    
    // 遮罩结束深度
    public int MaskingBackDepth = -1;

    // 判定框
    public Lib.Hitbox Hitbox = Lib.Hitbox.None;
    
    // 判定框触发类型
    public Lib.HitboxTriggerType HitboxTriggerType = Lib.HitboxTriggerType.Once;
    
    // 判定框触发重复间隔
    public float HitboxRepeatInterval = 10000;
    
    // 事件运行标签
    public string HitboxEventTag = "";
    
    
}