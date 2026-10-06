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
    
    // 整体缩放
    public float[] Scale = [100, 100];
    
    // 整体大小
    public float[] Size = [100, 100];
    
    // 前奏时长
    public float StartTime = 4;
    
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
    
    // 轨道颜色类型
    public Enum.Enum.TrackColorType TrackColorType = Enum.Enum.TrackColorType.Single;
    
    // 轨道主色调
    public string TrackColor = "debb7bff";
    
    // 轨道副色调
    public string SecondaryTrackColor = "ffffff";
    
    // 轨道颜色动画时长
    public float TrackColorAnimDuration = 2;
    
    // 轨道透明度
    public float TrackOpacity = 100;
    
    // 轨道风格
    public OALib.Enum.Enum.TrackStyle TrackStyle = OALib.Enum.Enum.TrackStyle.Standard;
    
    // 允许轨道发光
    public bool TrackGlowEnabled = false; 
    
    // 轨道发光颜色
    public string TrackGlowColor = "ffffff";
    
    
    
    // 是否添加星球
    public bool HasPlanet = false;
    
    // 是否有前奏
    public bool HasStart = false;
    
    // 是否有轨道变化
    public bool HasChange = false;
    
    // 变化
    // 变化时长
    public float ChangeDuration = 1;
    
    // 变化轨道颜色类型
    public Enum.Enum.TrackColorType ChangeTrackColorType = Enum.Enum.TrackColorType.Single;
    
    // 变化轨道主色调
    public string ChangeTrackColor = "debb7bff";
    
    // 变化轨道副色调
    public string ChangeSecondaryTrackColor = "ffffff";
    
    // 变化轨道颜色动画时长
    public float ChangeTrackColorAnimDuration = 2;
    
    // 变化轨道透明度
    public float ChangeTrackOpacity = 100;
    
    // 变化轨道风格
    public Enum.Enum.TrackStyle ChangeTrackStyle = Enum.Enum.TrackStyle.Standard;
    
    // 变化允许轨道发光
    public bool ChangeTrackGlowEnabled = false; 
    
    // 变化轨道发光颜色
    public string ChangeTrackGlowColor = "ffffff";


    private float[] TileData;
    private float[] AngleData;
    private float[] BpmData;
    private float[] TimeData;
    private int[] Twirl;

    private void CalculateMain()
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
        float posX = 0;
        float posY = 0;
        float outputFloorBpm = Calculate.CalculateBpmSimple(Output)[OutputFloor];
        float angleOffset = 0;
        bool hasMidSpinObject = false;
        bool hasMinSpinPlanet = false;
        bool hasSwitch = true;

        if (HasPlanet)
        {
            var addFirePlanet = new AddObject
            {
                Floor = OutputFloor,
                Position =  { [0] = DefaultPosition[0] + MathF.Cos(angle * deg2Rad) * Scale[0] / 100, [1] = DefaultPosition[1] + MathF.Sin(angle * deg2Rad) * Scale[0] / 100 },
                Tag         = $"{PlanetTag} {PlanetTag}_Fire",
                ObjectType = Enum.Enum.ObjectType.Planet,
                PlanetColorType = Enum.Enum.PlanetColorType.Custom,
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
                ObjectType = Enum.Enum.ObjectType.Planet,
                PlanetColorType = Enum.Enum.PlanetColorType.Custom,
                PlanetColor = IceColor,
                PlanetTailColor = IceColor,
                Scale       = Size,
                Depth       = Depth,
                Parallax    = Parallax,
            };
            Output.ActionAdd(addIcePlanet.Create());
        }

        for (int i = 0, floor = StartFloor; floor <= EndFloor; i++, floor++)
        {
            // 添加对象
            
            var frameAngle = Input.AngleData[floor].ToObject<float>();
            posX += MathF.Cos(angle * deg2Rad) * Scale[0] / 100;
            posY += MathF.Sin(angle * deg2Rad) * Scale[1] / 100;
            var addObject = new AddObject
            {
                Floor       = OutputFloor,
                TrackStyle  = TrackStyle,
                Tag         = $"{TileTag} {TileTag}_{i}",
                Position    = { [0] = posX + DefaultPosition[0], [1] = posY + DefaultPosition[1]},
                Depth       = i,
                Scale       = Size,
                Parallax    = Parallax,
                TrackColorType = TrackColorType,
                TrackColor = TrackColor,
                SecondaryTrackColor = SecondaryTrackColor,
                TrackColorAnimDuration = TrackColorAnimDuration,
                TrackOpacity = TrackOpacity,
                TrackGlowEnabled = TrackGlowEnabled,
                TrackGlowColor = TrackGlowColor,
            };
            // Rotation
            if (floor == 0)
            {
                addObject.Rotation = 0;
            }
            else if (hasMidSpinObject)
            {
                addObject.Rotation = 180 + Input.AngleData[floor - 2].ToObject<float>();
                hasMidSpinObject = false;
            }
            else
            {
                addObject.Rotation = Input.AngleData[floor - 1].ToObject<float>();
            }

            // TrackAngle  TrackType
            if (Input.AngleData[floor].ToObject<float>() == 999)
            {
                addObject.TrackType = Enum.Enum.TrackType.Midspin;
            }
            else
            {
                addObject.TrackAngle = tileAngle[floor];
            }
            Output.ActionAdd(addObject.Create());
            
            // 添加星球旋转
            if (HasPlanet)
            {
                if (HasStart)
                {
                    var moveDecorationsStart = new MoveDecorations
                    {
                        Floor = OutputFloor,
                    
                    };
                }
                
                var moveDecorations = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputFloor,
                    PositionOffset = { [0] = posX - 1, [1] = posY},
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

                // Rotation
                if (floor == 0)
                {
                    moveDecorations2.RotationOffset = 0;
                }
                else if (hasMinSpinPlanet)
                {
                    moveDecorations2.RotationOffset = 180 + Input.AngleData[floor - 2].ToObject<float>();
                    hasMinSpinPlanet = false;
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
                
                if (hasSwitch)
                {
                    moveDecorations2.Tag = moveDecorations3.Tag = $"{PlanetTag}_Ice";
                }
                else
                {
                    moveDecorations2.Tag = moveDecorations3.Tag = $"{PlanetTag}_Fire";
                }
                hasSwitch = !hasSwitch;
                
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
            }

            angleOffset += 3 * TimeData[i + StartFloor] * outputFloorBpm;
            
            // 轨道变化
            if (HasChange)
            {
                var setObject = new SetObject
                {
                    Floor = OutputFloor,
                    Tag = $"{TileTag}_{i}",
                    Duration = ChangeDuration,
                    TrackColorType = ChangeTrackColorType,
                    TrackColor = ChangeTrackColor,
                    SecondaryTrackColor = ChangeSecondaryTrackColor,
                    TrackColorAnimDuration = ChangeTrackColorAnimDuration,
                    TrackOpacity = ChangeTrackOpacity,
                    TrackStyle =  ChangeTrackStyle,
                    AngleOffset = angleOffset,
                    TrackGlowEnabled = ChangeTrackGlowEnabled,
                    TrackGlowColor = ChangeTrackGlowColor
                    
                };
                Output.ActionAdd(setObject.Create());
            }

            // 最后整理
            
            if (frameAngle == 999)
            {
                angle = 180 + Input.AngleData[floor - 1].ToObject<float>();
            }
            else
            {
                angle = frameAngle;
            }

            if (Input.AngleData[floor].ToObject<float>() == 999)
            {
                hasMidSpinObject = true;
                hasMinSpinPlanet = true;
            }
        }
    }
}