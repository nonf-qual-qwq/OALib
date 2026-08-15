namespace OALib.Lib;

public class Lib
{
    
    public enum EventType
    {
        SetSpeed, Twirl, Checkpoint, SetHitsound, PlaySound, SetPlanetRotation, Pause, AutoPlayTiles, ScalePlanets,
        ColorTrack, AnimateTrack, RecolorTrack, MoveTrack, PositionTrack,
        MoveDecorations, SetText, EmitParticle, SetParticle, SetObject, SetDefaultText,
        CustomBackground, Flash, MoveCamera, SetFilter, SetFilterAdvanced, HallOfMirrors, ShakeScreen, Bloom, ScreenTile, ScreenScroll, SetFrameRate,
        RepeatEvents, SetConditionalEvents, SetInputEvent,
        EditorComment, Bookmark,
        Hold, SetHoldSound, MultiPlanet, FreeRoam, FreeRoamTwirl, FreeRoamRemove, Hide, ScaleMargin, ScaleRadius,
        AddDecoration, AddText, AddObject, AddParticle
    }

    public enum ObjectType
    {
        Floor, Planet
    }

    public enum PlanetColorType
    {
        DefaultRed,DefaultBlue,Gold,Overseer,Custom
    }

    public enum TrackType
    {
        Normal,Midspin
    }

    public enum TrackColorType
    {
        Single,Glow,Blink,Switch,Rainbow,Volume
    }

    public enum TrackStyle
    {
        Standard,Neon,NeonLight,Basic,Gems,Minimal
    }

    public enum TrackIcon
    {
        None,Snail,DoubleSnail,Rabbit,DoubleRabbit,Swirl,Checkpoint,HoldArrowShort,HoldArrowLong,HoldReleaseShort,HoldReleaseLong,MultiPlanetTwo
    }

    public enum RelativeTo
    {
        Tile,Global,RedPlanet,BluePlanet,
    }

    public enum Ease
    {
        Linear,
        InSine, OutSine, InOutSine,
        InQuad, OutQuad, InOutQuad,
        InCubic, OutCubic, InOutCubic,
        InQuart, OutQuart, InOutQuart,
        InQuint, OutQuint, InOutQuint,
        InExpo, OutExpo, InOutExpo,
        InCirc, OutCirc, InOutCirc,
        InElastic, OutElastic, InOutElastic,
        InBack, OutBack, InOutBack,
        InBounce, OutBounce, InOutBounce,
        Flash, InFlash, OutFlash, InOutFlash,
    }

    public enum MaskingType
    {
        None,Mask,VisibleInsideMask,VisibleOutsideMask
    }

    public enum SpeedType
    {
        Bpm,Multiplier
    }

    public enum GameSound
    {
        Hitsound,Midspin
    }

    public enum Hitsound
    {
        Hat,Kick,Shaker,Sizzle,Chuck,
        ShakerLoud,None,Hammer,KickChroma,SnareAcoustic2,
        Sidestick,Stick,ReverbClack,Squareshot,PowerDown,
        PowerUp,KickHouse,KickRupture,HatHouse,SnareHouse,
        SnareVapor,ClapHit,ClapHitEcho,ReverbClap,FireTile,
        IceTile,VehiclePositive,VehicleNegative
    }

    public enum EasePartBehavior
    {
        Mirror,Repeat
    }

    public enum AngleCorrectionDir
    {
        None,Forward,Backward,
    }

    public enum TargetPlanet
    {
        FirePlanet,IcePlanet,GreenPlanet,All
    }

    public enum TrackAnimation
    {
        None,Assemble,Assemble_Far,Extend,Grow,Grow_Spin,Fade,Drop,Rise
    }

    public enum TrackDisappearAnimation
    {
        None,Scatter,Scatter_Far,Retract,Shrink,Shrink_Spin,Fade
    }

    public enum EffectTileType
    {
        ThisTile,Start,End
    }

    public enum TargetMode
    {
        Start,Stop,Clear
    }

    public enum BgDisplayMode
    {
        FitToScreen,Unscaled,Tiled
    }

    public enum RepeatEvents
    {
        Beat,Floor
    }

    public enum Target
    {
        Any,Action1,Action2,Confirm,Up,Down,Left,Right
    }

    public enum State
    {
        Down,Up
    }
}
