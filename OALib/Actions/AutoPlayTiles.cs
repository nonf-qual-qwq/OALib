using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class AutoPlayTiles : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.AutoPlayTiles;

    // 设置
    public bool Enabled = true;

    // 显示文本
    public bool ShowStatusText = true;

    // 安全砖块
    public bool SafetyTiles = false;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["enabled"] = Enabled,
            ["showStatusText"] = ShowStatusText,
            ["safetyTiles"] = SafetyTiles,
        };
        return jObject;
    }

}