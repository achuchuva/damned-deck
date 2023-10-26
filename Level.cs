using System;
using SplashKitSDK;

public class Level
{
    private EventManager _manager;
    private Game _game;
    private Player _player;

    public Level()
    {
        _game = new Game(new Board(), new Hand(), new Deck(), 15);
        _manager = new EventManager();
        _manager.AddSubscriber(e => _game.HandleEvent(e));
        _player = new Player(_game);
        Start();
    }

    public void Start()
    {
        _game.Board.AddCard(new Anomalus(), 0);
        _game.Hand.AddCard(new AcolyteOfPain());
        _game.Hand.AddCard(new RavagingGhoul());
        _game.Hand.AddCard(new BoulderfistOgre());
        _game.Deck.AddCard(new RavagingGhoul());
    }

    public void Draw()
    {
        Bitmap levelImage = SplashKit.LoadBitmap("level", "Images/level.png");
        SplashKit.DrawBitmap(levelImage, 0, 0);
        SplashKit.FreeBitmap(levelImage);

        SplashKit.DrawText(_game.Mana.ToString(), Color.Black, "Fonts/Roboto-Regular.ttf", 50, 560, 15);

        Bitmap restartButton = SplashKit.LoadBitmap("restart", "Images/restart.png");

        SplashKit.DrawBitmap(restartButton, 1100, 50);

        _game.Board.Draw(600);
        _game.Hand.Draw(700);
        _game.Deck.Draw();
    }

    public void Update()
    {
        _player.Update();
        _game.Board.Update();
        _game.Hand.Update();
    }
}