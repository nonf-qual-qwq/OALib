using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Lib;

public class MultiPlanet : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Lib.EventType EventType = Lib.EventType.MultiPlanet;
    
    // 多行星
    public Lib.Planets Planets = Lib.Planets.TwoPlanets;

    public JObject Create()
    {
        JObject jObject = new JObject()
        {
            ["floor"] = Floor,
            ["eventType"] = EventType.ToString(),
            ["planets"] = Planets.ToString()
        };
        return jObject;
    }
}