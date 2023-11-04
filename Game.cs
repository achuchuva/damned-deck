public class Game
{
    private EventManager _eventManager;
    public EventManager EventManager
    {
        get { return _eventManager; }
    }

    public Player? Player { get; set; }

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

    private Card? _targetingCard;
    public Card? TargetingCard
    {
        get { return _targetingCard; }
        set { _targetingCard = value; }
    }

    private bool _isLeft;

    public List<Card>? Targets { get; set; }
    private List<Card> _deadCards = new List<Card>();
    private List<Card> _summonedCards = new List<Card>();

    private Trigger _currentTrigger;
    public Trigger CurrentTrigger
    {
        get { return _currentTrigger; }
        set { _currentTrigger = value; }
    }

    private int _mana;
    public int Mana
    {
        get { return _mana; }
        set { _mana = value; }
    }

    private bool _levelComplete = false;
    public bool LevelComplete
    {
        get { return _levelComplete; }
        set { _levelComplete = value; }
    }

    public Game()
    {
        _eventManager = new EventManager();
        _eventManager.AddSubscriber(e => this.HandleEvent(e));
        _board = new Board();
        _hand = new Hand();
        _deck = new Deck();
        _mana = 0;
    }

    public void PlayCard(Card card, bool isLeft)
    {
        if (_mana >= card.Cost && (Board.MAX_CARDS > Board.CurrentCards.Count || card is Spell))
        {
            Hand.RemoveCard(card);
            _targetingCard = card;
            if (card is Minion)
            {
                _isLeft = isLeft;
                _eventManager.OnSummon(card, isLeft ? 0 : Board.CurrentCards.Count);
            }
            _eventManager.AddSubscriber(e => card.HandleEvent(e, this));
            _eventManager.OnPlay(card);
            Cleanup();
            _mana -= card.Cost;
        }
    }

    public void UseAbility(Card card)
    {
        _targetingCard = card;
        _eventManager.OnAbility(card);
        Cleanup();
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
                    _eventManager.OnDeath(damagedMinion);
                }
                break;
            case DeathEvent deathEvent:
                _deadCards.Add(deathEvent.DestroyedCard);
                break;
            case DrawEvent drawEvent:
                Deck.DrawCard(Hand, drawEvent.Amount);
                break;
            case ManaEvent manaEvent:
                _mana += manaEvent.Amount;
                break;
            case DiscoverEvent discoverEvent:
                Hand.AddCard(discoverEvent.DiscoveredCard);
                break;
            case HandEvent handEvent:
                Hand.AddCard(handEvent.AddedCard);
                break;
            case ChooseOneEvent chooseOneEvent:
                _targetingCard = chooseOneEvent.ChosenCard;
                chooseOneEvent.ChosenCard.HandleEvent(new PlayEvent(chooseOneEvent.ChosenCard), this);
                break;
            case HealthEvent healthEvent:
                Minion healedCard = (Minion)healthEvent.HealthCard;
                healedCard.AddHealth(healthEvent.Amount);
                break;
            case SummonEvent summonEvent:
                if (Board.CurrentCards.Count < Board.MAX_CARDS)
                {
                    _summonedCards.Add(summonEvent.SummonedCard);
                }
                break;
            default:
                break;
        }
    }

    public void Cleanup()
    {
        foreach (Card card in _deadCards)
        {
            Board.RemoveCard(card);
            _eventManager.RemoveSubscriber(e => card.HandleEvent(e, this));
        }
        foreach (Card card in _summonedCards)
        {
            Board.AddCard(card, _isLeft ? 0 : Board.CurrentCards.Count);
        }

        _deadCards.Clear();
        _summonedCards.Clear();

        CheckForGameOver();
    }

    public void CheckForGameOver()
    {
        if (Board.CurrentCards.Count == 0 &&
            Hand.CurrentCards.Count == 0 &&
            Deck.CurrentCards.Count == 0)
        {
            _levelComplete = true;
        }
    }

    public void CancelCard()
    {
        if (TargetingCard.TriggerType == Trigger.OnPlay)
        {
            Hand.AddCard(TargetingCard);
            Mana += TargetingCard.Cost;
        }
    }
}
