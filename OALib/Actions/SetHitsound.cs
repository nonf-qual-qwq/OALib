namespace OALib.Actions;

using Enum;
using Newtonsoft.Json.Linq;
public class SetHitsound : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Enum.EventType EventType = Enum.EventType.SetHitsound;
    
    // 设定目标
    public Enum.GameSound GameSound = Enum.GameSound.Hitsound;
    
    // 打拍声
    public Enum.Hitsound Hitsound = Enum.Hitsound.Kick;
    
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