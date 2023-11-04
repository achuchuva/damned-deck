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

    private EventType _currentTrigger;
    public EventType CurrentTrigger
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
                _eventManager.TriggerSubscribers(new Event(EventType.Summon, card));
            }
            _eventManager.AddSubscriber(e => card.HandleEvent(e, this));
            _eventManager.TriggerSubscribers(new Event(EventType.Play, card));
            Cleanup();
            _mana -= card.Cost;
        }
    }

    public void UseAbility(Card card)
    {
        _targetingCard = card;
        _eventManager.TriggerSubscribers(new Event(EventType.Ability, card));
        Cleanup();
    }

    public void HandleEvent(Event _event)
    {
        switch (_event.EventType)
        {
            case EventType.Damage:
                Minion damagedMinion = (Minion)_event.AffectedCard;
                damagedMinion.TakeDamage(_event.Amount);
                if (damagedMinion.HasDied)
                {
                    _eventManager.TriggerSubscribers(new Event(EventType.Death, damagedMinion));
                }
                break;
            case EventType.Death:
                _deadCards.Add(_event.AffectedCard);
                break;
            case EventType.Draw:
                Deck.DrawCard(Hand, _event.Amount);
                break;
            case EventType.Mana:
                _mana += _event.Amount;
                break;
            case EventType.Discover:
                Hand.AddCard(_event.AffectedCard);
                break;
            case EventType.Hand:
                for (int i = 0; i < _event.Amount; i++)
                {
                    Hand.AddCard(_event.AffectedCard.Clone());
                }
                break;
            case EventType.ChooseOne:
                _targetingCard = _event.AffectedCard;
                _event.AffectedCard.HandleEvent(new Event(EventType.Play, _event.AffectedCard), this);
                break;
            case EventType.Health:
                Minion healedCard = (Minion)_event.AffectedCard;
                healedCard.AddHealth(_event.Amount);
                break;
            case EventType.Summon:
                if (Board.CurrentCards.Count < Board.MAX_CARDS)
                {
                    if (TargetingCard.EffectType == Effect.SummonCopy)
                    {
                        _summonedCards.Add(_event.AffectedCard.Clone());
                    }
                    else
                    {
                        _summonedCards.Add(_event.AffectedCard);
                    }
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
        if (TargetingCard.TriggerType == EventType.Play)
        {
            Hand.AddCard(TargetingCard);
            Mana += TargetingCard.Cost;
        }
    }
}
