using System;
using SplashKitSDK;

public class Level
{
    private EventManager _manager;
    private Game _game;
    private Player _player;

    public Level()
    {
        _game = new Game(new Board(), new Hand(), new Deck(), 3);
        _manager = new EventManager(_game);
        _player = new Player(_game);
        Start();
    }

    public void Start()
    {
        _game.Board.AddCard(new AcolyteOfPain());
        _game.Board.AddCard(new AcolyteOfPain());
        _game.Hand.AddCard(new RavagingGhoul());
        _game.Hand.AddCard(new RavagingGhoul());
        _game.Hand.AddCard(new RavagingGhoul());
    }

    public void Draw()
    {
        Bitmap levelImage = SplashKit.LoadBitmap("level", "Images/level.png");
        SplashKit.DrawBitmap(levelImage, 0, 0);
        SplashKit.FreeBitmap(levelImage);

        SplashKit.DrawText(_game.Mana.ToString(), Color.White, 10, 10);

        _game.Board.Draw(600);
        _game.Hand.Draw(700);
    }

    public void Update()
    {
        _player.Update();
        _game.Board.Update();
        _game.Hand.Update();
    }
}