using SplashKitSDK;

public class RazorpetalVolley : Spell
{
    public RazorpetalVolley() : base(1, "Razorpetal Volley", "Add 2 Razorpetals to your hand that deal 1 damage.", Effect.Hand, Target.All, SplashKit.LoadBitmap("razorpetalvolley", "Images/razorpetalvolley.png"))
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(new List<Card> {
                new RazorPetal(),
                new RazorPetal()
            }).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                game.EventManager.OnHandAdd(card);
            }
        }
    }
}
