using SplashKitSDK;

public class Spell : Card
{

    public Spell(int cost, string name, string desc, Effect effectType, Target targetType, Bitmap image) : base(cost, name, desc, effectType, targetType, Trigger.OnPlay, image)
    {
    
    }

    public override void HandleEvent(Event e, Game game) { }

    public override void HandleEffect(List<Card> targets, Game game) { }

    public override Spell Clone()
    {
        return new Spell(
            this.Cost,
            this.Name,
            this.Description,
            this.EffectType,
            this.TargetType,
            this.Image
        );
    }
}
