using OALib.Actions;
using OALib.AdofaiArc;
using OALib.Decorations;

namespace OALib.Extra;

public class MultiTrack
{
    // 输入文件
    public AdofaiFile Input;
    
    // 输出文件
    public AdofaiFile Output;
    
    // 输入文件起始方块数
    public int StartFloor;
    
    // 输入文件终点方块数
    public int EndFloor;
    
    // 输出文件事件方块数
    public int OutputFloor;
    
    // 轨道标签
    public string TileTag = "Tile";
    
    // 是否添加星球
    public bool HasPlanet = false;
    
    // 是否有前奏
    public bool HasStart = false;
    
    // 整体缩放
    public float[] Scale = [100, 100];
    
    // 整体大小
    public float[] Size = [100, 100];
    
    // 轨道样式
    public OALib.Lib.Lib.TrackStyle TrackStyle = OALib.Lib.Lib.TrackStyle.Basic;
    
    // 前奏时长
    public float StartTime = 4;
    
    // 装饰起始方块
    public int StartDecoFloor;
    
    // 火球颜色
    public string FireColor = "ffffff";
    
    // 冰球颜色
    public string IceColor = "ffffff";
    
    // 星球标签
    public string PlanetTag = "Planet";
    
    // 播放音乐
    public bool HasBeat = false;
    
    // 初始位置
    public float[] DefaultPosition = [0, 0];
    
    // 深度
    public int Depth = 0;
    
    // 平行
    public float[] Parallax = [0, 0];
    


    private float[] TileData;
    private float[] AngleData;
    private float[] BpmData;
    private float[] TimeData;
    private int[] Twirl;

    public void CalculateMain()
    {
        TileData = Calculate.CalculateAngleData(Input);
        AngleData = Calculate.CalculateTwirlAngleData(Input);
        BpmData = Calculate.CalculateBpmSimple(Input);
        TimeData = Calculate.CalculateTime(Input);
        Twirl = Search.SearchTwirl(Input);
    }

    public void CreateMultiTrack()
    {
        CalculateMain();

        float[] tileAngle = TileData;

        const float deg2Rad = MathF.PI / 180f;

        float angle = 0f;
        float rotation = 0f;
        float posX = DefaultPosition[0];
        float posY = DefaultPosition[1];
        float angleOffset = 0;

        for (int i = 0, floor = StartFloor; floor <= EndFloor; i++, floor++)
        {
            var frameAngle = Input.AngleData[floor].ToObject<float>();
            posX += MathF.Cos(angle * deg2Rad) * Scale[0] / 100;
            posY += MathF.Sin(angle * deg2Rad) * Scale[1] / 100;
            var addObject = new AddObject
            {
                Floor       = OutputFloor,
                TrackStyle  = TrackStyle,
                Tag         = $"{TileTag} {TileTag}_{i}",
                Position    = { [0] = posX, [1] = posY },
                TrackAngle  = tileAngle[floor],
                Rotation    = floor == 0 ? 0 : Input.AngleData[floor - 1].ToObject<float>(),
                Depth       = Depth + i + i,
                Scale       = Size,
                Parallax    = Parallax,
            };
            Output.ActionAdd(addObject.Create());
            angle    = frameAngle;
        }

        if (HasPlanet)
        {
            
            angle = 0f;
            posX = 0f;
            posY = 0f;
            
            var addFirePlanet = new AddObject
            {
                Floor = OutputFloor,
                Position =  { [0] = DefaultPosition[0] + MathF.Cos(angle * deg2Rad) * Scale[0] / 100, [1] = DefaultPosition[1] + MathF.Sin(angle * deg2Rad) * Scale[0] / 100 },
                Tag         = $"{PlanetTag} {PlanetTag}_Fire",
                ObjectType = OALib.Lib.Lib.ObjectType.Planet,
                PlanetColorType = OALib.Lib.Lib.PlanetColorType.Custom,
                PlanetColor = FireColor,
                PlanetTailColor = FireColor,
                Scale       = Size,
                Parallax    = Parallax,
            };
            Output.ActionAdd(addFirePlanet.Create());
            
            var addIcePlanet = new AddObject
            {
                Floor = OutputFloor,
                Position =  { [0] = DefaultPosition[0] + MathF.Cos(angle * deg2Rad) * Scale[0] / 100, [1] = DefaultPosition[1]  + MathF.Sin(angle * deg2Rad) * Scale[0] / 100 },
                Tag         = $"{PlanetTag} {PlanetTag}_Ice",
                ObjectType = OALib.Lib.Lib.ObjectType.Planet,
                PlanetColorType = OALib.Lib.Lib.PlanetColorType.Custom,
                PlanetColor = IceColor,
                PlanetTailColor = IceColor,
                Scale       = Size,
                Depth = Depth,
                Parallax    = Parallax,
            };
            Output.ActionAdd(addIcePlanet.Create());

            if (HasStart)
            {
                var moveDecorations = new MoveDecorations
                {
                    Floor = OutputFloor,
                    
                };
            }

            
            float outputFloorBpm = Calculate.CalculateBpmSimple(Output)[OutputFloor];
            
            for (int i = 0, floor = StartFloor; floor <= EndFloor; i++, floor++)
            {
                var frameAngle = Input.AngleData[floor].ToObject<float>();
                var moveDecorations = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputFloor,
                    PositionOffset = { [0] = posX, [1] = posY },
                    PivotOffset = [0, 0],
                    AngleOffset = angleOffset,
                    Tag = $"{PlanetTag}",
                };
                Output.ActionAdd(moveDecorations.Create());

                var moveDecorations2 = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputFloor,
                    AngleOffset = angleOffset,
                    PivotOffset = [-1, 0],
                };


                if (floor == 0)
                {
                    moveDecorations2.RotationOffset = 0;
                }
                else
                {
                    moveDecorations2.RotationOffset = Input.AngleData[floor - 1].ToObject<float>();
                }

                
                var moveDecorations3 = new MoveDecorations
                {
                    Floor = OutputFloor,
                    Duration = TimeData[floor] * outputFloorBpm / 60,
                    RotationOffset =  moveDecorations2.RotationOffset - TileData[floor],
                    AngleOffset = angleOffset,
                };
                
                if (floor % 2 == 1)
                {
                    moveDecorations2.Tag = moveDecorations3.Tag = $"{PlanetTag}_Ice";
                }
                else
                {
                    moveDecorations2.Tag = moveDecorations3.Tag = $"{PlanetTag}_Fire";
                }
                
                Output.ActionAdd(moveDecorations2.Create());
                Output.ActionAdd(moveDecorations3.Create());

                if (HasBeat)
                {
                    var playSound = new PlaySound
                    {
                        Floor = OutputFloor,
                        AngleOffset = angleOffset
                    };
                    Output.ActionAdd(playSound.Create());
                }

                angle    = frameAngle;
                rotation = frameAngle;
                posX += MathF.Cos(angle * deg2Rad) * Scale[0] / 100;
                posY += MathF.Sin(angle * deg2Rad) * Scale[1] / 100;
                angleOffset += 3 * TimeData[i + StartFloor] * outputFloorBpm;
            }
        }
    }
}