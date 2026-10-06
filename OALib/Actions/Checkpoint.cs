using Newtonsoft.Json.Linq;

namespace OALib.Actions
{

    using Enum;

    public class Checkpoint : JObject
    {
        // 方块数量
        public int Floor = 0;

        // 事件类型
        public Enum.EventType EventType = Enum.EventType.Checkpoint;

        // 重置方块偏移
        public int TileOffset = 0;

        public JObject Create()
        {
            JObject jObject = new JObject()
            {
                ["floor"] = Floor,
                ["EventType"] = EventType.ToString(),
                ["TileOffset"] = TileOffset,
            };
            return jObject;
        }
    }
}