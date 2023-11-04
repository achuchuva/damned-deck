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

    public bool NeedsSummoning { get; set; }

    private bool _hasDied = false;
    public bool HasDied
    {
        get { return _hasDied; }
    }

    public Minion(int cost, string name, string desc, Effect effectType, Target targetType, Trigger triggerType, Bitmap image, int health) : base(cost, name, desc, effectType, targetType, triggerType, image)
    {
        _health = health;
        _maxHealth = health;
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

    public override void HandleEvent(Event _event, Game game) { }

    public override void HandleEffect(List<Card> targets, Game game) { }

    public override Minion Clone()
    {
        return new Minion(
            this.Cost,
            this.Name,
            this.Description,
            this.EffectType,
            this.TargetType,
            this.TriggerType,
            this.Image,
            this.Health
        );
    }
}
