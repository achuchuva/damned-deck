using System;
using SplashKitSDK;

public class Level
{
    private EventManager _manager;
    private Game _game;
    public Game Game
    {
        get { return _game; }
    }
    public int InitialMana { get; set; }
    public List<string> InitialBoardCards { get; set; }
    public List<string> InitialHandCards { get; set; }
    public List<string> InitialDeckCards { get; set; }

    private List<Button> _buttons;
    public List<Button> Buttons
    {
        get { return _buttons; }
    }

    public Level()
    {
        _game = new Game();
        InitialMana = 0;
        InitialBoardCards = new List<string>();
        InitialHandCards = new List<string>();
        InitialDeckCards = new List<string>();

        _buttons = new List<Button>();
        Rectangle rect = new Rectangle();
        rect.X = 1075;
        rect.Y = 50;
        rect.Height = 100;
        rect.Width = 100;
        _buttons.Add(new Button(rect, SplashKit.LoadBitmap("menubutton", "Images/menubutton.png"), ButtonType.Menu));
        rect.Y = 175;
        _buttons.Add(new Button(rect, SplashKit.LoadBitmap("restart", "Images/restart.png"), ButtonType.Restart));
    }

    public void SetUp()
    {
        _game.LevelComplete = false;
        _game.Mana = InitialMana;

        _game.Board.CurrentCards.Clear();
        foreach (string id in InitialBoardCards)
        {
            Card cardToAdd = CardFromId(id);
            _game.Board.AddCard(cardToAdd, 0);
            _game.EventManager.AddSubscriber(e => cardToAdd.HandleEvent(e, _game));
        }

        _game.Hand.CurrentCards.Clear();
        foreach (string id in InitialHandCards)
        {
            _game.Hand.AddCard(CardFromId(id));
        }

        _game.Deck.CurrentCards.Clear();
        foreach (string id in InitialDeckCards)
        {
            _game.Deck.AddCard(CardFromId(id));
        }
    }

    private Card CardFromId(string id)
    {
        switch (id)
        {
            case "AcolyteOfPain":
                return new AcolyteOfPain();
            case "Anomalus":
                return new Anomalus();
            case "BoulderfistOgre":
                return new BoulderfistOgre();
            case "RavagingGhoul":
                return new RavagingGhoul();
            default:
                throw new Exception("Unknown card ID: " + id);
        }
    }

    public void Draw()
    {
        Bitmap levelImage = SplashKit.LoadBitmap("level", "Images/level.png");
        SplashKit.DrawBitmap(levelImage, 0, 0);
        SplashKit.FreeBitmap(levelImage);

        SplashKit.DrawText(_game.Mana.ToString(), Color.Black, "Fonts/Roboto-Regular.ttf", 50, 560, 15);

        foreach (Button button in _buttons)
        {
            button.Draw();
        }

        _game.Board.Draw(600);
        _game.Hand.Draw(700);
        _game.Deck.Draw();
    }

    public void Update()
    {
        _game.Board.Update();
        _game.Hand.Update();
    }
}