using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Enum;
public class Pause : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Enum.EventType EventType = Enum.EventType.Pause;
    
    // 时长
    public float Duration = 1;
    
    // 计数次
    public int CountdownTicks = 0;
    
    // 角度校准
    public Enum.AngleCorrectionDir AngleCorrectionDir = Enum.AngleCorrectionDir.Backward;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["countdownTicks"] = CountdownTicks,
            ["angleCorrectionDir"] = AngleCorrectionDir.ToString(),
        };
        return jObject;
    }
}