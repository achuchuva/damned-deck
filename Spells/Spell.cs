using SplashKitSDK;

public class Spell : Card
{

    public Spell(int cost, string name, string desc, Bitmap image) : base(cost, name, desc, image)
    {
    
    }

    public override void HandleEvent(Event e, Game game)
    {

    }
}
