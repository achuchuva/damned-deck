using System;

public class PlayEvent
{

    private Card _playedCard;
    public Card PlayedCard
    {
        get { return _playedCard; }
    }

    public PlayEvent(Card playedCard)
    {
        _playedCard = playedCard;
    }
}