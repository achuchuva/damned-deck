using System;

public class ChooseOneEvent : Event
{
    private Card _chosenCard;
    public Card ChosenCard
    {
        get { return _chosenCard; }
    }

    public ChooseOneEvent(Card chosenCard)
    {
        _chosenCard = chosenCard;
    }
}