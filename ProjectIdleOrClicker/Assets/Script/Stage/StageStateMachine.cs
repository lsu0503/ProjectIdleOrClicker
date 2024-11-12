public interface IStageState
{
    public void EnterState();
    public void ExitState();
    public void Update();
}

public abstract class StageStateMachine
{
    protected IStageState curState;

    public void ChangeState(IStageState state)
    {
        curState?.ExitState();
        curState = state;
        curState?.EnterState();
    }

    public void Update()
    {
        curState?.Update();
    }
}