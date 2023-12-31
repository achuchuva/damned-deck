using SplashKitSDK;

public class Selection
{
    public Selection()
    {

    }

    public void GetTargets(Card card, Game game)
    {
        switch (card.TargetType)
        {
            case Target.None:
                card.HandleEffect(new List<Card>(), game);
                break;
            case Target.Random:
                card.HandleEffect(SelectRandomCards(game.Board.CurrentCards, 1), game);
                break;
            case Target.All:
                card.HandleEffect(game.Board.CurrentCards, game);
                break;
            case Target.Self:
                card.HandleEffect(new List<Card>() { card }, game);
                break;
            case Target.AllButSelf:
                card.HandleEffect(game.Board.CurrentCards.Except(new List<Card>() { card }).ToList(), game);
                break;
            case Target.Chosen:
                switch (card.EffectType)
                {
                    case Effect.Discover:
                        List<Card> targets = new List<Card>();
                        foreach (Card targetCard in Program.AllCards)
                        {
                            if (!targetCard.Token)
                                targets.Add(targetCard);
                        }
                        game.Targets = SelectRandomCards(targets, 3);
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                        break;
                    case Effect.DiscoverMinion:
                        targets = new List<Card>();
                        foreach (Card targetCard in Program.AllCards)
                        {
                            if (targetCard is Minion && !targetCard.Token)
                                targets.Add(targetCard);
                        }
                        game.Targets = SelectRandomCards(targets, 3);
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                        break;
                    case Effect.DiscoverSpell:
                        targets = new List<Card>();
                        foreach (Card targetCard in Program.AllCards)
                        {
                            if (targetCard is Spell && !targetCard.Token)
                                targets.Add(targetCard);
                        }
                        game.Targets = SelectRandomCards(targets, 3);
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                        break;
                    case Effect.ChooseOneRavenIdol:
                        game.Targets = new List<Card> { Program.GetCard("Awakened", true), Program.GetCard("Break Free", true) };
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                        break;
                    case Effect.ChooseOneWrath:
                        game.Targets = new List<Card> { Program.GetCard("Solar Wrath", true), Program.GetCard("Nature's Wrath", true) };
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                        break;
                    default:
                        if (game.Board.CurrentCards.Count > 0)
                        {
                            game.Targets = game.Board.CurrentCards;
                            game.Player.SetSelectionState(new TargetSelectionState());
                        }
                        break;
                }
                break;
            case Target.MurlocScout:
                card.HandleEffect(new List<Card>() { Program.GetCard("Murloc Scout", true) }, game);
                break;
            case Target.Razorpetal:
                card.HandleEffect(new List<Card>() { Program.GetCard("Razorpetal", true) }, game);
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
