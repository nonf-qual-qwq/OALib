using System.Threading.Tasks.Dataflow;
using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class SetFrameRate : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetFrameRate;
    
    // 启动
    public bool Enabled = true;
    
    // 帧率
    public float FrameRate = 5;
    
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
            ["enabled"] = Enabled,
            ["FrameRate"] = FrameRate,
            ["angleOffset"] = AngleOffset,
            ["eventTag"] = EventTag,
        };
        return jObject;
    }
}