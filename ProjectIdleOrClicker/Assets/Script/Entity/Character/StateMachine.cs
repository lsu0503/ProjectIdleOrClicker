public interface IState
{
    public void Enter();
    public void Exit();
    public void FixedUpdate(float _checkTIme);
}

public class StateMachine
{
    public IState currentState;

    public void ChangeState(IState nextState)
    {
        currentState?.Exit();
        currentState = nextState;
        currentState?.Enter();
    }

    public void FixedUpdate(float _checkTIme)
    {
        currentState?.FixedUpdate(_checkTIme);
    }
}
