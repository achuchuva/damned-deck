using System;
using SplashKitSDK;

public abstract class Card
{
    private int _cost;
    public int Cost
    {
        get { return _cost; }
    }
    // private Ability _ability;
    // public Ability Ability
    // {
    //     get { return _ability; }
    // }
    private string _name;
    public string Name
    {
        get { return _name; }
    }
    private string _description;
    public string Description
    {
        get { return _description; }
    }

    public Card(int cost, string name, string desc)
    {
        _cost = cost;
        _name = name;
        _description = desc;
    }

    public virtual void TakeDamage(int amount)
    {

    }

    public virtual void Die()
    {

    }

    public virtual void Discard()
    {
        
    }

    public abstract void HandleEvent(Event e);
}


// when this takes damage, draw a card
// battlecry: deal 1 damage to all