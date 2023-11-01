using System;
using SplashKitSDK;

class Arrow
{
    public Arrow()
    {

    }

    public void Draw(double startX, double startY, int offsetX, int offsetY)
    {
        double mouseX = SplashKit.MouseX();
        double mouseY = SplashKit.MouseY();

        // Draw the arrow body as a red line
        SplashKit.DrawLine(Color.Red, startX + offsetX, startY + offsetY, mouseX, mouseY);

        // Draw the arrowhead as a red triangle
        SplashKit.FillCircle(Color.Red, mouseX, mouseY, 10);
    }
}