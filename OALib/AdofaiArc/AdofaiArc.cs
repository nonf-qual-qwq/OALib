namespace OALib.AdofaiArc;

using Newtonsoft.Json.Linq;

public class AdofaiFile
{
    // ADOFAI文件目录
    public string FilePath = "";
    // ADOFAI文件
    public string FileData = "";
    // 角度
    public JArray AngleData = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    //设置
    public JObject Settings = new JObject();

    //事件
    public JArray Actions = [];
    //装饰
    public JArray Decorations = [];
    
    public void Load()
    {
        FileData = File.ReadAllText(FilePath);
        JObject jsonObject = JObject.Parse(FileData);
        AngleData = jsonObject["angleData"].ToObject<JArray>();
        Settings = jsonObject["settings"].ToObject<JObject>();
        Actions = jsonObject["actions"].ToObject<JArray>();
        Decorations = jsonObject["decorations"].ToObject<JArray>();

    }

    public void New()
    {
        FilePath = "..\\..\\..\\AdofaiArc\\Initialize.json";
        Load();
    }

    public void Clone(AdofaiFile file)
    {
        FilePath = file.FilePath;
        Load();
    }

    public void DecoAdd(JObject deco)
    {
        Decorations.Add(deco);
    }

    public void ActionAdd(JObject action)
    {
        Actions.Add(action);
    }

    public void Save()
    {
        JObject fileObject = new JObject
        {
            ["angleData"] = AngleData,
            ["settings"] = Settings,
            ["actions"] = Actions,
            ["decorations"] = Decorations
        };
        string json = fileObject.ToString(Newtonsoft.Json.Formatting.Indented);

        // 3. 确保目标目录存在
        string directory = Path.GetDirectoryName(FilePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        // 4. 写入文件（覆盖或新建）
        File.WriteAllText(FilePath, json);

    }
}