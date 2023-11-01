using SplashKitSDK;

public class Spell : Card
{

    public Spell(int cost, string name, string desc, EffectType effectType, TargetType targetType, Bitmap image) : base(cost, name, desc, effectType, targetType, TriggerType.OnPlay, image)
    {
    
    }

    public override void HandleEvent(Event e, Game game)
    {

    }
}
