using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;
public class PlaySound : JObject
{
    
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.PlaySound;
    
    // 打拍声
    public Object Hitsound = Lib.Hitsound.Kick;
    
    // 音乐偏移
    public int Offset = 0;
    
    // 时长 
    public int PlayDuration = 0;
    
    // 音高
    public int Pitch = 100;
    
    // 音量
    public int HitsoundVolume = 100;
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 事件标签
    public string EventTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
              ["floor"] = Floor,
              ["hitsound"] = Hitsound.ToString(),
              ["offset"] = Offset,
              ["playDuration"] = PlayDuration,
              ["pitch"] = Pitch,
              ["hitsoundVolume"] = HitsoundVolume,
              ["angleOffset"] = AngleOffset,
              ["eventTag"] = EventTag,
        };
        return jObject;
    }



}