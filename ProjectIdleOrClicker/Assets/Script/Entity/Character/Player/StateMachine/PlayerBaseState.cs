using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly Player player;
    protected Animator animator;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        player = stateMachine.player;
        animator = player.animator;
    }

    public abstract void Enter();

    public abstract void Exit();

    public abstract void FixedUpdate(float _checkTIme);

    public bool isOnMonster()
    {
        float distanceFromMonster = Mathf.Abs(player.status.gameObject.transform.position.z - StageManager.Instance.nearestMonsterDistance);

        if(distanceFromMonster <= ConstantCollection.BattleDistance)
            return true;

        else
            return false;
    }

    public bool isOnPosition()
    {
        Vector3 positionCoordinate = player.status.gameObject.transform.position - StageManager.Instance.CameraTarget.position;
        Vector3 positionDifference = positionCoordinate - player.position;

        if (positionDifference.magnitude <= ConstantCollection.PlayerPositionThreshold)
            return true;

        else
            return false;
    }
}