using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class CustomBackground : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.CustomBackground;
    
    // 颜色
    public string Color = "000000";
    
    // 背景图片
    public string BgImage = "";
    
    // 图片颜色
    public string ImageColor = "ffffff";
    
    // 平行
    public float?[] Parallax =  { 100, 100 };
    
    // 背景显示模式
    public Lib.BgDisplayMode BgDisplayMode = Lib.BgDisplayMode.FitToScreen;
    
    // 图片平滑
    public bool ImageSmoothing = true;
    
    // 旋转锁定
    public bool LockRot = false;
    
    // 循环背景
    public bool LoopBg = false;
    
    // 缩放比例
    public int ScalingRatio = 100;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 事件标签
    public string EventTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["color"] = Color,
            ["bgImage"] = BgImage,
            ["imageColor"] = ImageColor,
            ["parallax"] = JArray.FromObject(Parallax),
            ["bgDisplayMode"] = BgDisplayMode.ToString(),
            ["imageSmoothing"] = ImageSmoothing,
            ["lockRot"] = LockRot,
            ["loopBG"] = LoopBg,
            ["scalingRatio"] = ScalingRatio,
            ["angleOffset"] = AngleOffset,
            ["eventTag"] = EventTag,
            
        };
        return jObject;
    }

}