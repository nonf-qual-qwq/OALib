using Newtonsoft.Json.Linq;

namespace OALib.Decorations;

using Lib;

public class AddText : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.AddText;
    
    // 文本
    public string DecText = "";
    
    // 标签
    public string Tag = "";
    
    // 字体
    public Lib.Font Font = Lib.Font.Default;
    
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
    
    // 颜色
    public string Color = "ffffff";
    
    // 透明度
    public float Opacity = 100;
    
    // 深度
    public int Depth = -1;
    
    // 平行
    public float[] Parallax = { 0, 0 };
    
    // 视觉偏移
    public float[] ParallaxOffset =  { 0, 0 };

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            
        };
        return jObject;
    }
}