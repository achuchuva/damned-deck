using SplashKitSDK;

public class Selection
{
    private List<Card> _validTargets;

    public Selection(List<Card> allCards)
    {
        _validTargets = allCards;
    }

    public void GetTargets(Card card, Game game)
    {
        switch (card.TargetType)
        {
            case Target.None:
                card.HandleEffect(new List<Card>(), game);
                break;
            case Target.Random:
                int randomIndex = new Random().Next(0, _validTargets.Count);
                card.HandleEffect(new List<Card>() { _validTargets[randomIndex] }, game);
                break;
            case Target.All:
                card.HandleEffect(_validTargets, game);
                break;
            case Target.Self:
                card.HandleEffect(new List<Card>() { card }, game);
                break;
            case Target.AllButSelf:
                card.HandleEffect(_validTargets.Except(new List<Card>() { card }).ToList(), game);
                break;
            case Target.Chosen:
                if (_validTargets.Count > 0)
                {
                    game.Targets = _validTargets;
                    game.Player.SetSelectionState(new TargetSelectionState());
                }
                break;
            default:
                card.HandleEffect(new List<Card>(), game);
                break;
        }
    }
}
