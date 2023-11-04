using SplashKitSDK;

public class MurlocTidehunter : Minion
{
    public MurlocTidehunter() : base(2, "Murloc Tidehunter", "Battlecry: Summon a Murloc Scout.", Effect.Summon, Target.All, Trigger.OnPlay, SplashKit.LoadBitmap("murloctidehunter", "Images/murloctidehunter.png"), 1)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            new Selection(new List<Card> { new MurlocScout() }).GetTargets(this, game);
        }
    }

    public override void HandleEffect(List<Card> targets, Game game)
    {
        if (targets != null)
        {
            foreach (Card card in targets)
            {
                game.EventManager.OnSummon(card, game.Board.CurrentCards.Count);
            }
        }
    }
}
