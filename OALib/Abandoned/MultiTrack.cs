using System;
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
    
    // 中心
    public float[] Center = [0, 0];
    
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
    
    // 是否有轨道旋转
    public bool HasRotate = false;
    
    
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
    
    
    // 旋转
    
    // 时长
    public float RotateDuration = 1;
    
    // 角度
    public float RotateAngle = 0;
    
    // 逐帧
    public int Fps = 15;


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
        float posX = 0;
        float posY = 0;
        float outputFloorBpm = Calculate.CalculateBpmSimple(Output)[OutputFloor];
        float angleOffset = 0;
        
        float rotation = 0f;
        float rotationSpeed = RotateAngle / RotateDuration;

        float[] rotationPivot = [0, 0];
        
        bool hasMidSpinObject = false;
        bool hasMinSpinPlanet = false;
        bool hasSwitch = true;

        
        
        if (HasPlanet)
        {
            var addPlanet = new AddObject
            {
                Floor = OutputFloor,
                Position =  { [0] = DefaultPosition[0] + MathF.Cos(angle * deg2Rad) * Scale[0] / 100, [1] = DefaultPosition[1] + MathF.Sin(angle * deg2Rad) * Scale[0] / 100 },
                ObjectType = Enum.Enum.ObjectType.Planet,
                PlanetColorType = Enum.Enum.PlanetColorType.Custom,
                Scale       = Size,
                Parallax    = Parallax,
            };
            if (HasRotate)
            {
                addPlanet.PivotOffset = [0, 0];
                //addPlanet.PivotOffset[0] = (addPlanet.Position[0] - Center[0]) * MathF.Cos(addPlanet.Rotation * deg2Rad) + (addPlanet.Position[1] - Center[1]) * MathF.Sin(addPlanet.Rotation * deg2Rad);
                //addPlanet.PivotOffset[1] = - (addPlanet.Position[0] - Center[0]) * MathF.Sin(addPlanet.Rotation * deg2Rad) + (addPlanet.Position[1] - Center[1])  * MathF.Cos(addPlanet.Rotation * deg2Rad) ;
                addPlanet.Position[0] = Center[0];
                addPlanet.Position[1] = Center[1];
            }

            addPlanet.PlanetColor = addPlanet.PlanetTailColor = FireColor;
            addPlanet.Tag = $"{PlanetTag} {PlanetTag}_Fire";
            Output.ActionAdd(addPlanet.Create());
            
            addPlanet.PlanetColor = addPlanet.PlanetTailColor = IceColor;
            addPlanet.Tag = $"{PlanetTag} {PlanetTag}_Ice";
            Output.ActionAdd(addPlanet.Create());
        }

        if (HasRotate && RotateDuration > 0 && RotateDuration > 0)
        {
            var moveDecorationsAngle = new MoveDecorations
            {
                Floor = OutputFloor,
                Tag = $"{TileTag}",
                AngleOffset = 0,
                RotationOffset = RotateAngle,
                Duration =  RotateDuration,
            };
            Output.ActionAdd(moveDecorationsAngle.Create());
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

            if (HasRotate)
            {
                addObject.PivotOffset[0] = ((addObject.Position[0] - Center[0]) * MathF.Cos(addObject.Rotation * deg2Rad) + (addObject.Position[1] - Center[1]) * MathF.Sin(addObject.Rotation * deg2Rad) ) / Size[0] * 100;
                addObject.PivotOffset[1] = (- (addObject.Position[0] - Center[0]) * MathF.Sin(addObject.Rotation * deg2Rad) + (addObject.Position[1] - Center[1])  * MathF.Cos(addObject.Rotation * deg2Rad) ) / Size[1] * 100;
                rotationPivot = [addObject.Position[0] , addObject.Position[1]];
                addObject.Position[0] = Center[0];
                addObject.Position[1] = Center[1];
            }

            Output.ActionAdd(addObject.Create());
            
            /*
            if (HasPlanet && HasStart)
            {
                var moveDecorationsStart = new MoveDecorations
                {
                    Floor = OutputFloor,
                };
            }
            */
            
            // 添加星球旋转(无旋转)
            if (HasPlanet && !HasRotate)
            {
                
                var moveDecorations = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputFloor,
                    PositionOffset = { [0] = posX - Scale[0] / 100, [1] = posY},
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
                    PivotOffset = [ -Scale[0] / 100, 0],
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
                    AngleOffset = angleOffset ,
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


            }
            // 添加星球旋转(有旋转)
            else if (HasPlanet && HasRotate)
            {
                
                var moveDecorations = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputFloor,
                    PositionOffset = [0,0],
                    PivotOffset = [(rotationPivot[0] - Center[0]) / Size[0] * 100 , (rotationPivot[1] - Center[1]) / Size[0] * 100],
                    RotationOffset = angleOffset / 180 * rotationSpeed,
                    AngleOffset = angleOffset,
                    Tag =  $"{PlanetTag}",
                };
                
                var moveDecorations2 = new MoveDecorations
                {
                    Duration = TimeData[floor] * outputFloorBpm / 60,
                    Floor = OutputFloor,
                    RotationOffset = (TimeData[floor] * outputFloorBpm / 60 + angleOffset / 180) * rotationSpeed,
                    AngleOffset = angleOffset,
                    Tag = $"{PlanetTag}",
                };
                
                var moveDecorations3 = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputFloor,
                    PivotOffset = [-1, 0],
                    PositionOffset = {
                        [0] = ((rotationPivot[0] - Center[0]) * MathF.Cos( angleOffset / 180 * rotationSpeed * deg2Rad) - (rotationPivot[1] - Center[1]) * MathF.Sin( angleOffset / 180 * rotationSpeed * deg2Rad) ) / Size[0] * 100,
                        [1] = ((rotationPivot[0] - Center[0]) * MathF.Sin( angleOffset / 180 * rotationSpeed * deg2Rad) + (rotationPivot[1] - Center[1]) * MathF.Cos( angleOffset / 180 * rotationSpeed * deg2Rad) ) / Size[0] * 100
                    },
                    AngleOffset = angleOffset,
                };
                                
                // Rotation
                if (floor == 0)
                {
                    moveDecorations3.RotationOffset = (angleOffset / 180) * rotationSpeed;
                }
                else if (hasMinSpinPlanet)
                {
                    moveDecorations3.RotationOffset = 180 + Input.AngleData[floor - 2].ToObject<float>() + (angleOffset / 180) * rotationSpeed;
                    hasMinSpinPlanet = false;
                }
                else
                {
                    moveDecorations3.RotationOffset = Input.AngleData[floor - 1].ToObject<float>() + (angleOffset / 180) * rotationSpeed;
                }
                
                var moveDecorations4 = new MoveDecorations
                {
                    Duration = TimeData[floor] * outputFloorBpm / 60,
                    Floor = OutputFloor,
                    PositionOffset = {
                        [0] = ((rotationPivot[0] - Center[0]) * MathF.Cos( (TimeData[floor] * outputFloorBpm / 60 + angleOffset / 180) * rotationSpeed * deg2Rad) - (rotationPivot[1] - Center[1]) * MathF.Sin( (TimeData[floor] * outputFloorBpm / 60 + angleOffset / 180) * rotationSpeed * deg2Rad)) / Size[0] * 100,
                        [1] = ((rotationPivot[0] - Center[0]) * MathF.Sin( (TimeData[floor] * outputFloorBpm / 60 + angleOffset / 180) * rotationSpeed * deg2Rad) + (rotationPivot[1] - Center[1]) * MathF.Cos( (TimeData[floor] * outputFloorBpm / 60 + angleOffset / 180) * rotationSpeed * deg2Rad)) / Size[0] * 100
                    },
                    RotationOffset = moveDecorations3.RotationOffset - TileData[floor],
                    AngleOffset = angleOffset,
                };

                
                // Switch
                if (hasSwitch)
                {
                    moveDecorations2.Tag = $"{PlanetTag}_Fire";
                    moveDecorations3.Tag = moveDecorations4.Tag = $"{PlanetTag}_Ice";
                }
                else
                {
                    moveDecorations2.Tag = $"{PlanetTag}_Ice";
                    moveDecorations3.Tag = moveDecorations4.Tag = $"{PlanetTag}_Fire";
                }
                hasSwitch = !hasSwitch;
                
                Output.ActionAdd(moveDecorations.Create());
                Output.ActionAdd(moveDecorations2.Create()); 
                Output.ActionAdd(moveDecorations3.Create());
                Output.ActionAdd(moveDecorations4.Create());
            }

            if (HasBeat)
            {
                var playSound = new PlaySound
                {
                    Floor = OutputFloor,
                    AngleOffset = angleOffset
                };
                Output.ActionAdd(playSound.Create());
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