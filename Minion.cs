using SplashKitSDK;

public class Minion : Card
{
    private int _health;
    public int Health
    {
        get { return _health; }
    }

    private int _maxHealth;
    public int MaxHealth
    {
        get { return _maxHealth; }
    }

    private bool _hasDied = false;
    public bool HasDied
    {
        get { return _hasDied; }
    }

    private Target _triggerTargetType;
    public Target TriggerTargetType
    {
        get { return _triggerTargetType; }
    }

    public Minion(int cost, string name, string desc, Effect effectType, Target targetType, Target triggerTargetType, EventType triggerType, List<Event> effectEvents, Bitmap image, int health, bool token) : base(cost, name, desc, effectType, targetType, triggerType, effectEvents, image, token)
    {
        _health = health;
        _maxHealth = health;
        _triggerTargetType = triggerTargetType;
    }

    public override void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        _hasDied = true;
    }

    public override void AddHealth(int health)
    {
        _health += health;
        _maxHealth += health;
    }

    public override void HandleEvent(Event e, Game game)
    {
        if (e.EventType != TriggerType)
            return;

        switch (TriggerTargetType)
        {
            case Target.All:
                new Selection().GetTargets(this, game);
                break;
            case Target.AllMinions:
                if (e.AffectedCard != this && e.AffectedCard is Minion)
                {
                    new Selection().GetTargets(this, game);
                }
                break;
            case Target.Self:
                if (e.AffectedCard == this)
                {
                    new Selection().GetTargets(this, game);
                }
                break;
        }
    }

    public override Minion Clone()
    {
        return new Minion(
            this.Cost,
            this.Name,
            this.Description,
            this.EffectType,
            this.TargetType,
            this.TriggerTargetType,
            this.TriggerType,
            this.EffectEvents,
            this.Image,
            this.Health,
            this.Token
        );
    }
}
