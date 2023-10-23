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

    public Minion(int cost, string name, string desc, int health) : base(cost, name, desc)
    {
        _health = health;
        _maxHealth = health;
    }

    public override void TakeDamage(int amount)
    {
        _health -= amount;
        EventManager.GetInstance().OnDamage(this, amount);
        if (_health <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        EventManager.GetInstance().Game.Board.RemoveCard(this);
        EventManager.GetInstance().OnDeath(this);
    }

    public override void Heal(int amount)
    {
        if (_health < _maxHealth)
        {
            _health = Math.Max(_health + amount, MaxHealth);
            EventManager.GetInstance().OnDamage(this, amount);
        }
    }

    public override void SetMaxHealth(int health)
    {
        _maxHealth = MaxHealth;
    }

    public override void HandleEvent(Event _event) { }
}
