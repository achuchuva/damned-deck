using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window window = new Window("Damned Deck", 1200, 900);
        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            SplashKit.ClearWindow(window, Color.Beige);

            SplashKit.RefreshScreen();
        } while (!window.CloseRequested);
    }
}
