using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Enum;

public class SetInputEvent : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Enum.EventType EventType = Enum.EventType.SetInputEvent;
    
    // 侦测目标
    public Enum.Target Target = Enum.Target.Any;
    
    // 侦测状态
    public Enum.State State = Enum.State.Down;
    
    // 事件运行标签
    public bool IgnoreInput = false;
    
    // 事件运行标签
    public string TargetEventTag = "";
    
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
           ["Target"] = Target.ToString(),
           ["state"] = State.ToString(),
           ["ignoreInput"] = IgnoreInput,
           ["targetEventTag"] = TargetEventTag,
           ["angleOffset"] = AngleOffset,
           ["eventTag"] = EventTag,
        };
        return jObject;
    }

}