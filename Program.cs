using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Level level = new Level();

        Window window = new Window("Damned Deck", 1200, 900);
        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            level.Update();
            level.Draw();

            SplashKit.RefreshScreen();
        } while (!window.CloseRequested);
    }
}
