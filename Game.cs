public class Game
{
    private static Game _instance = GetInstance();
    private Board _board;
    public Board Board
    {
        get { return _board; }
    }
    private Hand _hand;
    public Hand Hand
    {
        get { return _hand; }
    }
    private Deck _deck;
    public Deck Deck
    {
        get { return _deck; }
    }
    private int _mana;
    public int Mana
    {
        get { return _mana; }
    }

    public Game(Board startingBoard, Hand startingHand, Deck startingDeck, int startingMana)
    {
        _board = startingBoard;
        _hand = startingHand;
        _deck = startingDeck;
        _mana = startingMana;
        _instance = this;
    }

    public static Game GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Game(new Board(), new Hand(), new Deck(), 10);
        }
        return _instance;
    }

    public void PlayCard(Card card, bool isLeft)
    {
        if (_mana >= card.Cost)
        {
            Game.GetInstance().Hand.RemoveCard(card);
            if (card is Minion)
            {
                if (isLeft)
                {
                    Game.GetInstance().Board.AddCard(card, 0);
                }
                else
                {
                    Game.GetInstance().Board.AddCard(card, Game.GetInstance().Board.CurrentCards.Count);
                }
            }
            EventManager.GetInstance().OnPlay(card);
            Cleanup();
            _mana -= card.Cost;
        }
    }

    public void HandleEvent(Event _event)
    {
        switch (_event)
        {
            case DamageEvent damageEvent:
                Minion damagedMinion = (Minion)damageEvent.DamagedCard;
                damagedMinion.TakeDamage(damageEvent.Amount);
                if (damagedMinion.HasDied)
                {
                    EventManager.GetInstance().OnDeath(damagedMinion);
                }
                break;
            case DrawEvent drawEvent:
                Deck.DrawCard(1);
                break;
            default:
                break;
        }
    }

    public void Cleanup()
    {
        List<Minion> minionsToDie = new List<Minion>();
        foreach (Minion minion in Game.GetInstance().Board.CurrentCards)
        {
            if (minion.HasDied)
            {
                minionsToDie.Add(minion);
            }
        }

        Game.GetInstance().Board.CurrentCards.RemoveAll(minion => minionsToDie.Contains(minion));

        CheckForGameOver();
    }

    public void CheckForGameOver()
    {
        if (Board.CurrentCards.Count == 0 &&
            Hand.CurrentCards.Count == 0 &&
            Deck.CurrentCards.Count == 0)
        {
            Console.WriteLine("You win!");
        }
    }
}
