using Newtonsoft.Json.Linq;

namespace OALib.Actions
{
    using Enum;

    public class AnimateTrack : JObject
    {
        // 方块数量
        public int Floor = 0;

        // 事件类型
        public Enum.EventType EventType = Enum.EventType.AnimateTrack;
    
        // 动画前节拍
        public int BeatsAhead = 3;
    
        // 动画后节拍
        public int BeatsBehind = 4;
    
        // 轨道升起动画
        public Enum.TrackAnimation? TrackAnimation = Enum.TrackAnimation.None;
    
        //轨道消失动画
        public Enum.TrackDisappearAnimation? TrackDisappearAnimation = Enum.TrackDisappearAnimation.None;
        public JObject Create()
        {
            JObject jObject = new JObject()
            {
                ["floor"] = Floor,
                ["eventType"] = EventType.ToString(),
                ["beatsAhead"] = BeatsAhead,
                ["beatsBehind"] = BeatsBehind,
            
            };

            if (TrackAnimation != null)
            {
                jObject["trackAnimation"] = TrackAnimation.ToString();
            }

            if (TrackDisappearAnimation != null)
            {
                jObject["trackDisappearAnimation"] = TrackDisappearAnimation.ToString();
            }

            return jObject;

        }
    }
}

