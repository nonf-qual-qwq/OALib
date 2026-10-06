using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class FreeRoam : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.FreeRoam;
    
    // 时长
    public float Duration = 16;
    
    // 自由区域大小
    public int[] Size = [4, 4];
    
    // 位置偏移
    public float[] PositionOffset = [0, 0];
    
    // 退出过度时长
    public float OutTime = 4;
    
    // 缓速
    public Lib.Ease OutEase = Lib.Ease.InOutSine;
    
    // 在离开区域移动摄像头
    public bool OutCam = true;
    
    // 强音打拍音效
    public Lib.Hitsound HitsoundOnBeats = Lib.Hitsound.None;
    
    // 弱音打拍音效
    public Lib.Hitsound HitsoundOffBeats = Lib.Hitsound.None;

    

}