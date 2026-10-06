using Newtonsoft.Json.Linq;

namespace OALib.Actions;

using Enum;

public class MultiPlanet : JObject
{
    // 方块数量
    public int Floor = 0;
    
    // 事件类型
    public Enum.EventType EventType = Enum.EventType.MultiPlanet;
    
    // 多行星
    public Enum.Planets Planets = Enum.Planets.TwoPlanets;

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