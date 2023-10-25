using System;
using SplashKitSDK;

public class Player
{
    private Game _game;
    public Game Game
    {
        get { return _game; }
    }

    public Player(Game game)
    {
        _game = game;
    }

    public void Start()
    {

    }

    public void Update()
    {
        foreach (Card card in Game.Hand.CurrentCards)
        {
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && card.IsClicked((int)SplashKit.MouseX(), (int)SplashKit.MouseY()))
            {
                card.IsBeingDragged = !card.IsBeingDragged;
                Point2D mousePos = new Point2D();
                mousePos.X = SplashKit.MouseX();
                mousePos.Y = SplashKit.MouseY();
                Rectangle rect = new Rectangle();
                rect.X = 50;
                rect.Y = 100;
                rect.Width = 950;
                rect.Height = 300;
                if (SplashKit.PointInRectangle(mousePos, rect))
                {
                    // OMG! We played a card from hand!
                    bool isLeft = mousePos.X <= 600;
                    Play(card, isLeft);
                }
            }
        }
    }

    public void Play(Card card, bool isLeft)
    {
        card.Play(isLeft);
        Console.WriteLine(Game.Board.CurrentCards.Count);
        EventManager.GetInstance().OnPlay(card); 
    }

    public void UseAbility()
    {

    }
}