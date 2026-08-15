using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class RepeatEvents : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.RepeatEvents;
    
    // 重复类型
    public Lib.RepeatEvents RepeatEvent = Lib.RepeatEvents.Beat;
    
    // 重复次数
    public int Repetitions = 1;
    
    // 重复方块数
    public int FloorCount = 1;
    
    // 间隔
    public float Interval = 1;
    
    // 间隔长度
    public int GapLength = 1;
    
    // 在当前执行
    public bool ExecuteOnCurrentFloor = false;
    
    // 标签
    public string Tag = "";

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["repetitions"] = Repetitions,
            ["floorCount"] = FloorCount,
            ["interval"] = Interval,
            ["gapLength"] = GapLength,
            ["executeOnCurrentFloor"] = ExecuteOnCurrentFloor,
            ["tag"] = Tag,
        };
        return jObject;
    }
}