namespace OALib.Actions;

using Lib;
using Newtonsoft.Json.Linq;
public class SetHitsound : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetHitsound;
    
    // 设定目标
    public Lib.GameSound GameSound = Lib.GameSound.Hitsound;
    
    // 打拍声
    public Lib.Hitsound Hitsound = Lib.Hitsound.Kick;
    
    // 音量
    public int HitsoundVolume = 100;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["gameSound"] = GameSound.ToString(),
            ["hitsound"] = Hitsound.ToString(),
            ["hitsoundVolume"] = HitsoundVolume,
        };
        return jObject;
    }
}