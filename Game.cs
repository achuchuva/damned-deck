public class Game
{
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

    public Game()
    {

    }
}