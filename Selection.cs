using SplashKitSDK;

public enum TargetType
{
    Self,
    Random,
    All,
    AllButSelf,
    UserChoice
}

public class Selection
{
    private List<Card> _validTargets;
    public List<Card> ValidTargets
    {
        get { return _validTargets; }
    }

    public Selection(List<Card> allCards)
    {
        _validTargets = allCards;
    }

    public List<Card> GetTargets(TargetType targetType, Card sourceCard, int count = 1)
    {
        switch (targetType)
        {
            case TargetType.Self:
                return new List<Card> { sourceCard };

            case TargetType.Random:
                return GetRandomTargets(count);

            case TargetType.All:
                return _validTargets;

            case TargetType.AllButSelf:
                return _validTargets.Except(new List<Card> { sourceCard }).ToList();

            case TargetType.UserChoice:
                return GetUserChosenTargets(sourceCard);

            default:
                return new List<Card>();
        }
    }

    private List<Card> GetRandomTargets(int count)
    {
        Random random = new Random();
        return _validTargets.OrderBy(_ => random.Next()).Take(count).ToList();
    }

    private List<Card> GetUserChosenTargets(Card sourceCard)
    {
        List<Card> chosenTargets = new List<Card>();
        // int selectedIndex;

        // while (chosenTargets.Count < sourceCard.TargetCount)
        // {
        //     if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 0 && selectedIndex < _validTargets.Count)
        //     {
        //         chosenTargets.Add(_validTargets[selectedIndex]);
        //     }
        // }

        return chosenTargets;
    }
}
