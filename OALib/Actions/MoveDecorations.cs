namespace OALib.Actions;

using Lib;
using Newtonsoft.Json.Linq;

public class MoveDecorations : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.MoveDecorations;
    
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
    
    // 可见
    public bool? Visible;
    
    // 相对于
    public Lib.RelativeTo? RelativeTo;
    
    // 图片
    public string? DecorationImage;
    
    // 位置
    public float?[] Position = new float?[2] { null, null };
    
    // 轴心偏移
    public float?[] PivotOffset = new float?[2] { null, null };
    
    // 旋转
    public float? RotationOffset;
    
    // 大小
    public float?[] Scale = new float?[2] { null, null };
    
    // 颜色
    public string? Color;
    
    // 透明度
    public float? Opacity;
    
    // 深度
    public int? Depth;
    
    // 平行
    public float?[] Parallax = new float?[2] { null, null };
    
    // 视觉偏移
    public float?[] ParallaxOffset =  new float?[2] { null, null };
    
    // 图像平滑
    public bool? ImageSmoothing;

    // 遮罩类型
    public Lib.MaskingType? MaskingType;
    
    // 使用遮罩深度
    public bool? UseMaskingDepth;
    
    // 遮罩起始深度
    public int? MaskingFrontDepth;
    
    // 遮罩结束深度
    public int? MaskingBackDepth;

    public JObject Create()
    {
        JObject jObject = new JObject
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["tag"] = Tag,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["eventTag"] = EventTag,
        };

        if (Visible.HasValue)
        {
            jObject["visible"] = Visible.Value;
        }

        if (RelativeTo.HasValue)
        {
            jObject["relativeTo"] = RelativeTo.Value.ToString();
        }

        if (DecorationImage != null)
        {
            jObject["decorationImage"] = DecorationImage;
        }

        if (Position[0] != null || Position[1] != null)
        {
            jObject["position"] = JArray.FromObject(Position);
        }

        if (PivotOffset[0] != null || PivotOffset[1] != null)
        {
            jObject["pivotOffset"] = JArray.FromObject(PivotOffset);
        }

        if (RotationOffset.HasValue)
        {
            jObject["rotationOffset"] = RotationOffset.Value;
        }

        if (Scale[0] != null || Scale[1] != null)
        {
            jObject["scale"] = JArray.FromObject(Scale);
        }

        if (Color != null)
        {
            jObject["color"] = Color;
        }

        if (Opacity.HasValue)
        {
            jObject["opacity"] = Opacity.Value;
        }

        if (Depth.HasValue)
        {
            jObject["depth"] = Depth.Value;
        }

        if (Parallax[0] != null || Parallax[1] != null)
        {
            jObject["parallax"] = JArray.FromObject(Parallax);
        }

        if (ParallaxOffset[0] != null || ParallaxOffset[1] != null)
        {
            jObject["parallaxOffset"] = JArray.FromObject(ParallaxOffset);
        }

        if (ImageSmoothing.HasValue)
        {
            jObject["imageSmoothing"] = ImageSmoothing.Value;
        }

        if (MaskingType != null)
        {
            jObject["maskingType"] = MaskingType.ToString();
        }

        if (UseMaskingDepth.HasValue)
        {
            jObject["useMaskingDepth"] = UseMaskingDepth.Value;
        }

        if (MaskingFrontDepth.HasValue)
        {
            jObject["maskingFrontDepth"] = MaskingFrontDepth.Value;
        }

        if (MaskingBackDepth.HasValue)
        {
            jObject["maskingBackDepth"] = MaskingBackDepth.Value;
        }

        return jObject;
    }

}