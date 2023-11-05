using SplashKitSDK;

public class View
{
    public void DrawMenu(Menu menu)
    {
        Bitmap menuImage = SplashKit.LoadBitmap("menu", "Images/menu.png");
        SplashKit.DrawBitmap(menuImage, 0, 0);
        SplashKit.FreeBitmap(menuImage);

        for (int i = 0; i < menu.LevelButtons.Count; i++)
        {
            DrawButton(menu.LevelButtons[i], (i + 1).ToString());
        }
    }

    public void DrawLevel(Level level)
    {
        Bitmap levelImage = SplashKit.LoadBitmap("level", "Images/level.png");
        SplashKit.DrawBitmap(levelImage, 0, 0);
        SplashKit.FreeBitmap(levelImage);

        SplashKit.DrawText(level.Game.Mana.ToString(), Color.Black, "Fonts/Roboto-Regular.ttf", 50, 560, 15);

        foreach (Button button in level.Buttons)
        {
            DrawButton(button);
        }

        DrawBoard(600, level.Game.Board.CurrentCards);
        DrawHand(700, level.Game.Hand.CurrentCards);
        DrawDeck(level.Game.Deck.CurrentCards.Count > 0);

        if (level.Game.Player.SelectionState is TargetSelectionState)
        {
            DrawArrow(
                level.Game.TargetingCard.X,
                level.Game.TargetingCard.Y,
                level.Game.TargetingCard.Width / 2,
                level.Game.TargetingCard.Height / 2);
        }
        else if (level.Game.Player.SelectionState is DiscoverSelectionState)
        {
            int totalWidth = level.Game.Targets.Count * 125;
            int startX = 500 - totalWidth / 2;
            foreach (Card card in level.Game.Targets)
            {
                card.X = startX;
                card.Y = 300;
                DrawCard(card);
                startX += 300;
            }
        }

        if (level.Game.LevelComplete)
        {
            DrawWinText();
        }
    }

    private void DrawButton(Button button, string text = "")
    {
        SplashKit.DrawBitmap(button.Image, button.Rectangle.X, button.Rectangle.Y);
        SplashKit.DrawText(text, Color.Black, "Fonts/aptos-black.ttf", 75, button.Rectangle.X + 25, button.Rectangle.Y + 5);
    }

    private void DrawBoard(int centreX, List<Card> Cards)
    {
        int totalWidth = Cards.Count * 125;
        int startX = centreX - totalWidth / 2;

        foreach (Card card in Cards)
        {
            if (!card.IsBeingDragged)
            {
                card.X = startX;
                card.Y = 150;
            }
            DrawCard(card);
            startX += 125;
        }
    }

    private void DrawHand(int centreX, List<Card> Cards)
    {
        int totalWidth = Cards.Count * 125;
        int startX = centreX - totalWidth / 2;

        foreach (Card card in Cards)
        {
            if (!card.IsBeingDragged)
            {
                card.X = startX;
                card.Y = 600;
            }
            DrawCard(card);
            startX += 105;
        }
    }

    private void DrawDeck(bool cardsInDeck)
    {
        if (cardsInDeck)
        {
            SplashKit.FillRectangle(Color.White, 1115, 400, 35, 150);
        }
    }

    private void DrawCard(Card card)
    {
        SplashKit.FillRectangle(Color.White, card.X, card.Y, card.Width, card.Height);
        card.Image.Draw(card.X, card.Y);

        SplashKit.DrawLine(Color.Black, card.X, card.Y + (card.Height / 3), card.X + card.Width, card.Y + (card.Height / 3));

        DrawMultilineText(card.Name, "Fonts/Roboto-Regular.ttf", Color.Black, (int)card.X + 5, (int)card.Y + (card.Height / 3) + 5, 100, 12);

        SplashKit.DrawLine(Color.Black, card.X, card.Y + (card.Height / 2), card.X + card.Width, card.Y + (card.Height / 2));

        DrawMultilineText(card.Description, "Fonts/Roboto-Thin.ttf", Color.Black, (int)card.X + 5, (int)card.Y + (card.Height / 2) + 5, 100, 12);

        SplashKit.DrawRectangle(Color.Black, card.X, card.Y, card.Width, card.Height);

        SplashKit.FillCircle(Color.Yellow, card.X, card.Y, 10);
        SplashKit.DrawText(card.Cost.ToString(), Color.Black, "Fonts/Roboto-Regular.ttf", 12, card.X - 3, card.Y - 6);

        if (card is Minion)
        {
            Minion minion = (Minion)card;
            SplashKit.FillCircle(Color.Red, minion.X + minion.Width, minion.Y + minion.Height, 10);
            SplashKit.DrawText(minion.Health.ToString(), Color.Black, "Fonts/Roboto-Regular.ttf", 12, minion.X + minion.Width - 3, minion.Y + minion.Height - 6);
        }
    }

    private void DrawMultilineText(string text, string font, Color color, int x, int y, int maxWidth, int lineHeight)
    {
        List<string> lines = SplitTextIntoLines(text, maxWidth);
        int lineY = y;

        foreach (string line in lines)
        {
            SplashKit.DrawText(line, color, font, 12, x, lineY);
            lineY += lineHeight;
        }
    }

    private List<string> SplitTextIntoLines(string text, int maxWidth)
    {
        List<string> lines = new List<string>();
        string[] words = text.Split(' ');
        string currentLine = "";

        foreach (string word in words)
        {
            if (SplashKit.TextWidth(currentLine + " " + word, "Fonts/Roboto-Thin.ttf", 15) <= maxWidth)
            {
                currentLine += (currentLine == "" ? "" : " ") + word;
            }
            else
            {
                lines.Add(currentLine);
                currentLine = word;
            }
        }

        if (!string.IsNullOrEmpty(currentLine))
        {
            lines.Add(currentLine);
        }

        return lines;
    }

    private void DrawArrow(double startX, double startY, int offsetX, int offsetY)
    {
        double mouseX = SplashKit.MouseX();
        double mouseY = SplashKit.MouseY();

        SplashKit.DrawLine(Color.Red, startX + offsetX, startY + offsetY, mouseX, mouseY);

        SplashKit.FillCircle(Color.Red, mouseX, mouseY, 10);
    }

    private void DrawWinText()
    {
        SplashKit.DrawText("Cards Obliterated", Color.Green, "Fonts/Roboto-Regular.ttf", 150, 25, 300);
    }
}