using System;
using SplashKitSDK;

public class Level
{
    private EventManager _manager;
    private Game _game;

    public Level()
    {
        _manager = new EventManager();
        _game = new Game(new Board(), new Hand(), new Deck(), 3);
    }

    public void Draw()
    {
        Bitmap levelImage = SplashKit.LoadBitmap("level", "Images/level.png");
        SplashKit.DrawBitmap(levelImage, 0, 0);
        SplashKit.FreeBitmap(levelImage);

        SplashKit.DrawText(_game.Mana.ToString(), Color.White, 10, 10);

        _game.Board.AddCard(new AcolyteOfPain());
        _game.Hand.AddCard(new RavagingGhoul());

        _game.Board.Draw();
        _game.Hand.Draw();
    }
}