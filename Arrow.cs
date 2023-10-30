using System;
using SplashKitSDK;

class Arrow
{
    private double startX;
    private double startY;

    public Arrow(double x, double y)
    {
        startX = x;
        startY = y;
    }

    public void Draw()
    {
        double mouseX = SplashKit.MouseX();
        double mouseY = SplashKit.MouseY();

        // Draw the arrow body as a red line
        SplashKit.DrawLine(Color.Red, startX, startY, mouseX, mouseY);

        // Draw the arrowhead as a red triangle
        SplashKit.FillCircle(Color.Red, mouseX, mouseY, 10);
    }
}