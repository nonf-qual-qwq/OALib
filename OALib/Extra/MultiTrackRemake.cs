using System;
using OALib.Actions;
using OALib.AdofaiArc;
using OALib.Decorations;

namespace OALib.Extra;

public class MultiTrackRemake
{
    //* 基础设置 *//
    // 输入文件
    public AdofaiFile InputFile;
    
    // 输出文件
    public AdofaiFile OutputFile;
    
    // 输入文件所取方块数
    public int[] InputTile = new int[2];
    
    // 输出文件所取方块数
    public int OutputTile;
    
    // 轨道标签
    public string TileTag = "Tile";
    
    // 轨道大小
    public float[] Scale = [100, 100];
    
    // 轨道距离
    public float[] Size = [100, 100];
    
    // 平行
    public float[] Parallax = [0, 0];
    
    // 中心位置 (关于输出轨道)
    public float[] Center = [0, 0];
    
    // 起始位置 (关于输出轨道)
    public float[] DefaultPosition = [0, 0];
    
    
    //* 轨道设置 *//
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
    
    
    //* 轨道变化 *//
    // 是否轨道变化
    public bool HasChange = false;
    
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
    
    
    //* 星球设置 *//
    // 是否使用星球
    public bool HasPlanet = false;
    
    // 星球标签
    public string PlanetTag = "Planet";
    
    // 火球颜色
    public string FireColor = "ffffff";
    
    // 冰球颜色
    public string IceColor = "ffffff";
    
    
    //* 音效设置 *//
    // 是否使用音效
    public bool HasSound = false;
    
    // 音效
    public OALib.Enum.Enum.Hitsound Hitsound = OALib.Enum.Enum.Hitsound.Kick;
    
    //音量
    public int HitsoundVolume = 100;
    
    
    //* 旋转设置 *//
    // 是否使用旋转
    public bool HasRotate = false;
    
    // 时长
    public float RotateDuration = 1;
    
    // 角度
    public float RotateAngle = 0;

    public void Create()
    {
        if (InputFile == null)
        {
            Console.Error.WriteLine("没有选择输入文件");
        }
        if (OutputFile == null)
        {
            Console.Error.WriteLine("没有选择输出文件");
        }
        if (InputTile == null)
        {
            Console.Error.WriteLine("没有选择输入方块");
        }
        if (OutputTile == null)
        {
            Console.Error.WriteLine("没有选择输出方块");
        }
        
        
        float[] angleData = InputFile.AngleData.ToObject<float[]>();
        float[] timeData = Calculate.CalculateTime(InputFile);
        float[] tileData = Calculate.CalculateAngleData(InputFile);

        float outputBpm = Calculate.CalculateBpmSimple(OutputFile)[OutputTile];
        
        float posX = 0;
        float posY = 0;
        float angleOffset = 0;
        
        bool hasMidSpin = false;
        
        const float deg2Rad = MathF.PI / 180f;
        float rotationSpeed = RotateAngle / RotateDuration;

        if (HasPlanet)
        {
            var addPlanet = new AddObject
            {
                Floor = OutputTile,
                Position = [Center[0], Center[1]],
                Scale = [Scale[0], Scale[1]],
                ObjectType = Enum.Enum.ObjectType.Planet,
                PlanetColorType = Enum.Enum.PlanetColorType.Custom,
            };
            
            addPlanet.PlanetColor = addPlanet.PlanetTailColor = FireColor;
            addPlanet.Tag = $"{PlanetTag} {PlanetTag}_Fire";
            OutputFile.ActionAdd(addPlanet.Create());
            
            addPlanet.PlanetColor = addPlanet.PlanetTailColor = IceColor;
            addPlanet.Tag = $"{PlanetTag} {PlanetTag}_Ice";
            OutputFile.ActionAdd(addPlanet.Create());
        }
        
        if (HasRotate)
        {
            var addTileDeco = new MoveDecorations
            {
                Floor = OutputTile,
                Tag = $"{TileTag}",
                Duration = RotateDuration,
                RotationOffset = RotateAngle,
            };
            OutputFile.ActionAdd(addTileDeco.Create());
        }

        for (int nowTile = InputTile[0]; nowTile <= InputTile[1]; nowTile++)
        {
            float pivX = posX + DefaultPosition[0] - Center[0];
            float pivY = posY + DefaultPosition[1] - Center[1];
            float rotation;
            
            if (nowTile == 0)
            {
                rotation = 0;
            }
            else if (hasMidSpin)
            {
                rotation = 180 + angleData[nowTile - 2];
            }
            else
            {
                rotation = angleData[nowTile - 1];
            }
            
            float[] rotationPiv = CalculateTilePivot(pivX, pivY, rotation);
            
            var addTile = new AddObject
            {
                Floor = OutputTile,
                Tag = $"{TileTag} {TileTag}_{nowTile - InputTile[0]}",
                Position = [Center[0], Center[1]],
                PivotOffset = [rotationPiv[0] * Size[0] / Scale[0], rotationPiv[1] *  Size[1] / Scale[1]],
                Rotation = rotation,
                Scale = [Scale[0], Scale[1]],
                TrackAngle = tileData[nowTile],
                Parallax = [Parallax[0], Parallax[1]],
                Depth = nowTile - InputTile[0],
                
                TrackColorType = TrackColorType,
                TrackColor = TrackColor,
                SecondaryTrackColor = SecondaryTrackColor,
                TrackColorAnimDuration = TrackColorAnimDuration,
                TrackOpacity = TrackOpacity,
                TrackStyle = TrackStyle,
                TrackGlowEnabled = TrackGlowEnabled,
                TrackGlowColor = TrackGlowColor,
            };

            if (HasPlanet && !HasRotate)
            {
                var addPlanetDeco1 = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputTile,
                    PositionOffset = [pivX * Size[0] / 100, pivY * Size[1] / 100],
                    PivotOffset = [0, 0],
                    AngleOffset = angleOffset,
                };

                var addPlanetDeco2 = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputTile,
                    PositionOffset = [pivX * Size[0] / 100, pivY * Size[1] / 100],
                    PivotOffset = [Scale[0] / 100, 0],
                    AngleOffset = angleOffset,
                };
                
                // Rotation
                if (nowTile == 0)
                {
                    addPlanetDeco2.RotationOffset = 180;
                }
                else if (hasMidSpin)
                {
                    addPlanetDeco2.RotationOffset = angleData[nowTile - 2];
                }
                else
                {
                    addPlanetDeco2.RotationOffset = 180 + angleData[nowTile - 1];
                }
                
                var addPlanetDeco3 = new MoveDecorations
                {
                    Floor = OutputTile,
                    Duration = timeData[nowTile] * outputBpm / 60,
                    RotationOffset =  addPlanetDeco2.RotationOffset - tileData[nowTile],
                    AngleOffset = angleOffset,
                };

                if (nowTile % 2 == 1)
                {
                    addPlanetDeco1.Tag = $"{PlanetTag}_Fire";
                    addPlanetDeco2.Tag = addPlanetDeco3.Tag = $"{PlanetTag}_Ice";
                    
                }
                else
                {
                    addPlanetDeco1.Tag = $"{PlanetTag}_Ice";
                    addPlanetDeco2.Tag = addPlanetDeco3.Tag = $"{PlanetTag}_Fire";
                }

                OutputFile.ActionAdd(addPlanetDeco1.Create());
                OutputFile.ActionAdd(addPlanetDeco2.Create());
                OutputFile.ActionAdd(addPlanetDeco3.Create());
            }

            if (HasPlanet && HasRotate)
            {
                float[] rotationPos = CalculateTilePivot2(pivX, pivY, angleOffset * rotationSpeed / 180);
                float[] rotationNewPos = CalculateTilePivot2(pivX, pivY, (timeData[nowTile] * outputBpm / 60 + angleOffset / 180) * rotationSpeed);
                var addPlanetDeco1 = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputTile,
                    PositionOffset = [0, 0],
                    PivotOffset = [pivX * Size[0] / Scale[0], pivY * Size[1] / Scale[1]],
                    RotationOffset = angleOffset * rotationSpeed / 180,
                    AngleOffset = angleOffset,
                };
                
                var addPlanetDeco2 = new MoveDecorations
                {
                    Duration = timeData[nowTile] * outputBpm / 60,
                    Floor = OutputTile,
                    RotationOffset = (timeData[nowTile] * outputBpm / 60 + angleOffset / 180) * rotationSpeed,
                    AngleOffset = angleOffset,
                };

                var addPlanetDeco3 = new MoveDecorations
                {
                    Duration = 0,
                    Floor = OutputTile,
                    PivotOffset = [Scale[0] / 100, 0],
                    PositionOffset = [rotationPos[0] * Size[0] / 100, rotationPos[1] * Size[1] / 100],
                    AngleOffset = angleOffset,
                };
                
                // Rotation
                if (nowTile == 0)
                {
                    addPlanetDeco3.RotationOffset = 180 + angleOffset * rotationSpeed / 180;
                }
                else if (hasMidSpin)
                {
                    addPlanetDeco3.RotationOffset = angleData[nowTile - 2] + angleOffset * rotationSpeed / 180;
                }
                else
                {
                    addPlanetDeco3.RotationOffset = 180 + angleData[nowTile - 1] + angleOffset * rotationSpeed / 180;
                }
                
                var addPlanetDeco4 = new MoveDecorations
                {
                    Duration = timeData[nowTile] * outputBpm / 60,
                    Floor = OutputTile,
                    RotationOffset = addPlanetDeco3.RotationOffset - tileData[nowTile] + (timeData[nowTile] * outputBpm / 60) * rotationSpeed  ,
                    AngleOffset = angleOffset,
                    
                    // 直线模拟曲线
                    PositionOffset = [rotationNewPos[0] * Size[0] / 100, rotationNewPos[1] * Size[1] / 100],
                };
                

                if (nowTile % 2 == 1)
                {
                    addPlanetDeco1.Tag = addPlanetDeco2.Tag = $"{PlanetTag}_Fire";
                    addPlanetDeco3.Tag = addPlanetDeco4.Tag = $"{PlanetTag}_Ice";
                    
                }
                else
                {
                    addPlanetDeco1.Tag = addPlanetDeco2.Tag = $"{PlanetTag}_Ice";
                    addPlanetDeco3.Tag = addPlanetDeco4.Tag = $"{PlanetTag}_Fire";
                }

                OutputFile.ActionAdd(addPlanetDeco1.Create());
                OutputFile.ActionAdd(addPlanetDeco2.Create());
                OutputFile.ActionAdd(addPlanetDeco3.Create());
                OutputFile.ActionAdd(addPlanetDeco4.Create());
            }

            if (HasSound)
            {
                var playSound = new PlaySound
                {
                    Floor = OutputTile,
                    AngleOffset = angleOffset,
                    Hitsound = Hitsound,
                    HitsoundVolume = HitsoundVolume,
                };
                
                OutputFile.ActionAdd(playSound.Create());
            }

            posX += MathF.Cos(angleData[nowTile] * deg2Rad);
            posY += MathF.Sin(angleData[nowTile] * deg2Rad);
            angleOffset += timeData[nowTile] * outputBpm * 3;
            OutputFile.ActionAdd(addTile.Create());
            
            // 轨道变化
            if (HasChange)
            {
                var setObject = new SetObject
                {
                    Floor = OutputTile,
                    Tag = $"{TileTag}_{nowTile - InputTile[0]}",
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
                OutputFile.ActionAdd(setObject.Create());
            }
            
            hasMidSpin = false;
            if (angleData[nowTile] == 999)
            {
                hasMidSpin = true;
            }
        }
    }

    private float[] CalculateTilePivot(float pivX, float pivY, float rotation)
    {
        float deg2Rad = MathF.PI / 180f;
        
        float[] newPiv =  new float[2];
        newPiv[0] = pivX * MathF.Cos(rotation * deg2Rad) + pivY * MathF.Sin(rotation * deg2Rad);
        newPiv[1] = pivY * MathF.Cos(rotation * deg2Rad) - pivX * MathF.Sin(rotation * deg2Rad);
        return newPiv;
    }
    
    private float[] CalculateTilePivot2(float pivX, float pivY, float rotation)
    {
        float deg2Rad = MathF.PI / 180f;
        
        float[] newPiv =  new float[2];
        newPiv[0] = pivX * MathF.Cos(rotation * deg2Rad) - pivY * MathF.Sin(rotation * deg2Rad);
        newPiv[1] = pivY * MathF.Cos(rotation * deg2Rad) + pivX * MathF.Sin(rotation * deg2Rad);
        return newPiv;
    }
}

