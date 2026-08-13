using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class AnimateTrack : JObject
{
    // 方块数量
    public int Floor = 0;

    // 事件类型
    public Lib.EventType EventType = Lib.EventType.AnimateTrack;
    
    // 动画前节拍
    public int BeatsAhead = 3;
    
    // 动画后节拍
    public int BeatsBehind = 4;
    
    // 轨道升起动画
    public Lib.TrackAnimation? TrackAnimation = Lib.TrackAnimation.None;
    
    //轨道消失动画
    public Lib.TrackDisappearAnimation? TrackDisappearAnimation = Lib.TrackDisappearAnimation.None;
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