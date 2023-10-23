using System;
using SplashKitSDK;

public class Ability
{
    public Trigger _trigger;
    public Effect _effect;

    public Ability(Trigger trigger, Effect effect)
    {
        _trigger = trigger;
        _effect = effect;
    }

    public void Activate()
    {

    }
}
