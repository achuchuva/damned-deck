public class Minion : Card
{
    private int _health;
    public int Health
    {
        get { return _health; }
    }

    public Minion(int cost, Ability ability, string desc, int health) : base(cost, ability, desc)
    {
        _health = health;
    }

    public override void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health < 0)
        {
            Die();
        }
    }

    public override void Die()
    {

    }

    public override void HandleEvent(Event _event)
    {

    }
}
