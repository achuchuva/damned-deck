using SplashKitSDK;

public class Selection
{
    private List<Card> _validTargets;

    public Selection(List<Card> allCards)
    {
        _validTargets = allCards;
    }

    public List<Card> GetTargets(Card card)
    {
        switch (card.TargetType)
        {
            case TargetType.None:
                return new List<Card>();
            case TargetType.Random:
                int randomIndex = new Random().Next(0, _validTargets.Count);
                return new List<Card>() { _validTargets[randomIndex] };
            case TargetType.All:
                return _validTargets;
            case TargetType.Self:
                return new List<Card>() { card };
            case TargetType.AllButSelf:
                return _validTargets.Except(new List<Card>() { card }).ToList();
            default:
                return new List<Card>();
        }
    }
}
