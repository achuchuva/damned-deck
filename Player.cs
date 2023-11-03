public class Player
{
    private IPlayerSelectionState _selectionState;
    public IPlayerSelectionState SelectionState
    {
        get { return _selectionState; }
    }

    public Level? CurrentLevel { get; set; }

    public Player()
    {
        SetSelectionState(new MenuSelectionState());
    }

    public void Update(Level levelContext, Menu menuContext)
    {
        _selectionState.Update(menuContext, levelContext, this);
    }

    public void SetSelectionState(IPlayerSelectionState state)
    {
        _selectionState = state;
    }
}