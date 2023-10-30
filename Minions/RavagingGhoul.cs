using SplashKitSDK;

public class RavagingGhoul : Minion
{
    public RavagingGhoul() : base(3, "Ravaging Ghoul", "Battlecry: Deal 1 damage to all other minions.", SplashKit.LoadBitmap("ravagingghoul", "Images/ravagingghoul.png"), 3)
    {

    }

    public override void HandleEvent(Event _event, Game game)
    {
        if (!(_event is PlayEvent))
            return;

        PlayEvent playEvent = (PlayEvent)_event;

        if (playEvent.PlayedCard == this)
        {
            Selection selection = new Selection(game.Board.CurrentCards);
            List<Card> targets = selection.GetTargets(TargetType.AllButSelf, this);
            foreach (Card card in targets)
            {
                if (card != this)
                {
                    game.EventManager.OnDamage(card, 1);
                }
            }
        }

        base.HandleEvent(_event, game);
    }
}
