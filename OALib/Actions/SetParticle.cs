using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class SetParticle : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.SetParticle;
    
    // 时长
    public float Duration = 1;
    
    // 标签
    public string Tag = "";
    
    // 角度偏移
    public float AngleOffset = 0;
    
    // 缓速
    public Lib.Ease Ease = Lib.Ease.Linear;
    
    // 事件标签
    public string EventTag = "";
    
    // 模式
    public Lib.TargetMode? TargetMode;
    
    // 粒子持续事件
    public float?[] ParticleLifetime = new float?[2] { null, null };

    // 发送频率
    public int? EmissionRate;
    
    // 模拟速度
    public float? SimulationSpeed;
    
    // 锁定转角
    public bool? LockRotation;
    
    // 锁定大小
    public bool? LockScale;
    
    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["duration"] = Duration,
            ["tag"] = Tag,
            ["angleOffset"] = AngleOffset,
            ["ease"] = Ease.ToString(),
            ["eventTag"] = EventTag,
        };
        if (TargetMode.HasValue)
        {
            jObject["targetMode"] = TargetMode.ToString();
        }

        if (ParticleLifetime[0] != null | ParticleLifetime[1] != null)
        {
            jObject["particleLifetime"] = JArray.FromObject(ParticleLifetime);
        }

        if (EmissionRate != null)
        {
            jObject["emissionRate"] = EmissionRate;
        }

        if (SimulationSpeed != null)
        {
            jObject["simulationSpeed"] = SimulationSpeed.ToString();
        }

        if (LockRotation != null)
        {
            jObject["lockRotation"] = LockRotation;
        }

        if (LockScale != null)
        {
            jObject["lockScale"] = LockScale;
        }

        return jObject;
    }
}