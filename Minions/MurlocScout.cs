using SplashKitSDK;

public class MurlocScout : Minion, IToken
{
    public MurlocScout() : base(1, "Murloc Scout", "", Effect.None, Target.None, Trigger.None, SplashKit.LoadBitmap("murlocscout", "Images/murlocscout.png"), 1)
    {
        
    }
}
