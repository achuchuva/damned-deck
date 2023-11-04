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
                card.HandleEffect(SelectRandomCards(_validTargets, 1), game);
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
                    if (card.EffectType == Effect.Discover)
                    {
                        game.Targets = SelectRandomCards(_validTargets, 3);
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                    }
                    else if (card.EffectType == Effect.ChooseOne)
                    {
                        game.Targets = _validTargets;
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                    }
                    else
                    {
                        game.Targets = _validTargets;
                        game.Player.SetSelectionState(new TargetSelectionState());
                    }
                }
                break;
            default:
                card.HandleEffect(new List<Card>(), game);
                break;
        }
    }

    private List<Card> SelectRandomCards(List<Card> cards, int count)
    {
        if (count >= cards.Count)
        {
            return cards; 
        }

        Random random = new Random();
        List<Card> result = new List<Card>();

        while (result.Count < count)
        {
            int randomIndex = random.Next(cards.Count);
            Card randomCard = cards[randomIndex];
            if (!result.Contains(randomCard))
            {
                result.Add(randomCard);
            }
        }

        return result;
    }
}
