using System.Collections.Generic;
using System.IO;

namespace OALib.AdofaiArc
{
    
    using Newtonsoft.Json.Linq;

    public class AdofaiFile
    {
        // ADOFAI文件目录
        public string FilePath = "";

        // ADOFAI文件
        public string FileData = "";

        // 角度
        public JArray AngleData = new JArray();

        //设置
        public JObject Settings = new JObject();

        //事件
        public JArray Actions = new JArray();

        //装饰
        public JArray Decorations = new JArray();

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

        public void AngleAdd(JValue angle)
        {
            AngleData.Add(angle);
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

            string directory = Path.GetDirectoryName(FilePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(FilePath, json);

        }
    }

    public class Search
    {
        public static JToken[] SearchActions(string name, AdofaiFile input)
        {
            List<JToken> actions = [];
            foreach (JToken action in input.Actions)
            {
                if (action["eventType"].ToObject<string>() == name)
                {
                    actions.Add(action);
                }
            }
            return actions.ToArray();
        }
        
        public static int[] SearchTwirl(AdofaiFile input)
        {
            List<int> twirl = [];
            foreach (JToken action in input.Actions)
            {
                if (action["eventType"].ToObject<string>() ==  "Twirl")
                {
                    twirl.Add(action["floor"].ToObject<int>());
                }
            }
            return twirl.ToArray();
        }
    }

    public class Calculate
    {
        // 单个角度规范化
        public static float AngleUniformity(float angle)
        {
            float num = angle;
            if ( num > 360.0 || num < -360.0)
                num = angle % 360f;
            if ( num < 0.0)
                num += 360f;
            return num;
        }
        
        // 计算文件谱面的轨道bpm
        // 限制：只允许每个方块最多有一个bpm事件
        public static float[] CalculateBpmSimple(AdofaiFile input)
        {
            int count = input.AngleData.Count;
            float[] bpm = new float[count];
            float nowBpm = input.Settings["bpm"].ToObject<float>();

            JToken[] bpmList = Search.SearchActions("SetSpeed", input);
            int idx = 0;

            bpm[0] = nowBpm;
            for (int floor = 1; floor < count; floor++)
            {
                while (idx < bpmList.Length &&
                       bpmList[idx]["floor"].ToObject<int>() == floor)
                {
                    var item = bpmList[idx];
                    if (item["speedType"].ToObject<string>() == "Bpm")
                        nowBpm = item["beatsPerMinute"].ToObject<float>();
                    else
                        nowBpm *= item["bpmMultiplier"].ToObject<float>();
                    idx++;
                }
                bpm[floor] = nowBpm;
            }
            return bpm;
        }
        
        // 计算谱面轨道角度（无事件)
        public static float[] CalculateAngleData(AdofaiFile input)
        {
            float[] angleDataFloat = input.AngleData.ToObject<float[]>();
            float[] angleData1 = new float[angleDataFloat.Length];
            for (int index = 0; index < angleDataFloat.Length; ++index)
            {
                int num = 0;
                if (angleDataFloat[index] == 999)
                {
                    angleData1[index] = 0.0f;
                }
                else
                {
                    while (index - 1 - num >= 0 && angleDataFloat[index - 1 - num] == 999)
                        ++num;
                    if (index - 1 - num < 0)
                    {
                        angleData1[index] = 180f - angleDataFloat[index];
                    }
                    else
                    {
                        angleData1[index] = angleDataFloat[index - 1 - num] - angleDataFloat[index];
                        if (num % 2 == 0)
                            angleData1[index] += 180f;
                    }
                }
                angleData1[index] = AngleUniformity(angleData1[index]);
            }
            return angleData1;
        }
        
        // 计算谱面轨道角度（旋转)
        public static float[] CalculateTwirlAngleData(float[] angleData, int[] twirlData)
        {
            var twirlSet = new HashSet<int>(twirlData);
            bool twirl = false;
            for (int i = 0; i < angleData.Length; i++)
            {
                if (twirlSet.Contains(i))
                    twirl = !twirl;

                if (twirl && angleData[i] != 0f && angleData[i] != 360)
                    angleData[i] = 360f - angleData[i];
            }
            return angleData;
        }

        public static float[] CalculateTwirlAngleData(AdofaiFile input)
        {
            float[] angleData = CalculateAngleData(input);
            int[] twirlData = Search.SearchTwirl(input);
            CalculateTwirlAngleData(angleData, twirlData);
            return angleData;
        }
        
        // 计算谱面轨道时长 (事件只有旋转)
        
        public static float[] CalculateTime(float[] angle, float[] bpm)
        {
            float[] time = new float[angle.Length];

            for (int i = 0; i < time.Length; i++)
            {
                time[i] = angle[i] / 3 / bpm[i];
            }
        
            return time;
        }
        
        public static float[] CalculateTime(AdofaiFile input)
        {
            float[] angle =  CalculateTwirlAngleData(input);
            float[] bpm = CalculateBpmSimple(input);
            
            float[] time = CalculateTime(angle, bpm);
            return time;
        }
        
        
        
    }
}