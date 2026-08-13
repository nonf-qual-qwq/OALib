using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;
public class SetSpeed : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetSpeed;
    
    // 设置速度类型
    public Lib.SpeedType SpeedType = Lib.SpeedType.Bpm;
    
    // BPM
    public float BeatsPerMinute = 100;
    
    // 倍频器
    public float BpmMultiplier = 1;
    
    // 角度偏移
    public float AngleOffset = 0;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["speedType"] = SpeedType.ToString(),
            ["beatsPerMinute"] = BeatsPerMinute,
            ["bpmMultiplier"] = BpmMultiplier,
            ["angleOffset"] = AngleOffset
        };
        
        return jObject;
    }

}