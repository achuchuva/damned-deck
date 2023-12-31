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

    public Card? TargetingCard { get;set; }

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

    public int Mana { get;set; }

    public bool LevelComplete { get;set; }

    public Game()
    {
        _eventManager = new EventManager();
        _eventManager.AddSubscriber(e => this.HandleEvent(e));
        _board = new Board();
        _hand = new Hand();
        _deck = new Deck();
        Mana = 0;
    }

    public void PlayCard(Card card, bool isLeft)
    {
        if (Mana >= card.Cost && (Board.MAX_CARDS > Board.CurrentCards.Count || card is Spell))
        {
            Hand.RemoveCard(card);
            TargetingCard = card;
            if (card is Minion)
            {
                _isLeft = isLeft;
                _eventManager.TriggerSubscribers(new Event(EventType.Summon, card));
            }
            _eventManager.AddSubscriber(e => card.HandleEvent(e, this));
            _eventManager.TriggerSubscribers(new Event(EventType.Play, card));
            Cleanup();
            Mana -= card.Cost;
        }
    }

    public void UseAbility(Card card)
    {
        TargetingCard = card;
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
                Mana += _event.Amount;
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
                TargetingCard = _event.AffectedCard;
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

    private void CheckForGameOver()
    {
        if (Board.CurrentCards.Count == 0 &&
            Hand.CurrentCards.Count == 0 &&
            Deck.CurrentCards.Count == 0)
        {
            LevelComplete = true;
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
