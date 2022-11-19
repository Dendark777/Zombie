public class StateMachine 
{
    public event StateHandler OnStateChanged;
    public delegate void StateHandler(IState state, IState oldState);

    private IState _currentState;
    private IState _oldState;

    public  IState CurrentState => _currentState;
    public IState OldState => _oldState;  
    
    public void ChangeState(IState state)
    {
        _oldState = _currentState;
        _currentState.Exit();
        _currentState = state;
        state.Enter();
        OnStateChanged.Invoke(CurrentState, OldState);
    }

    public void InitializeState(IState state)
    {
        _currentState = state;
        state.Enter();
    }
}
