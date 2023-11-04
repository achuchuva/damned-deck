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
                        game.Targets = SelectRandomCards(Program.AllCards, 3);
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                        break;
                    case Effect.DiscoverMinion:
                        game.Targets = SelectRandomCards(Program.AllCards.Where(c => c is Minion).ToList(), 3);
                        game.Player.SetSelectionState(new DiscoverSelectionState());
                        break;
                    case Effect.DiscoverSpell:
                        game.Targets = SelectRandomCards(Program.AllCards.Where(c => c is Spell).ToList(), 3);
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
