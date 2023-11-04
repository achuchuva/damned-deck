using SplashKitSDK;

public class Spell : Card
{
    public Spell(int cost, string name, string desc, Effect effectType, Target targetType, List<Event> effectEvents, Bitmap image, bool token) : base(cost, name, desc, effectType, targetType, EventType.Play, effectEvents, image, token)
    {

    }

    public override void HandleEvent(Event e, Game game)
    {
        if (e.EventType != EventType.Play)
            return;

        if (e.AffectedCard == this)
        {
            new Selection().GetTargets(this, game);
        }
    }

    public override Spell Clone()
    {
        return new Spell(
            this.Cost,
            this.Name,
            this.Description,
            this.EffectType,
            this.TargetType,
            this.EffectEvents,
            this.Image,
            this.Token
        );
    }
}
