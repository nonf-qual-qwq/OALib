using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class ScreenTile : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.ScreenTile;
    
    // 时长
    public float Duration = 0;
    
    // 平铺
    public float[] Tile = [1, 1];
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 事件标签
    public string EventTag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["tile"] = JArray.FromObject(Tile)
        };
        return jObject;
    }

}