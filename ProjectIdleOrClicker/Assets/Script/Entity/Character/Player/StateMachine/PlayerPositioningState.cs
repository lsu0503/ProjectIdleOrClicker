
using System;
using UnityEngine;

public class PlayerPositioningState : PlayerBaseState
{
    private Rigidbody rigid;
    private float positionCheckTimer;

    public PlayerPositioningState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        rigid = player.rigid;
    }

    public override void Enter()
    {
        positionCheckTimer = 0.0f;
        animator.SetBool("isMoving", true);
    }

    public override void Exit()
    {
        rigid.velocity = Vector3.zero;
    }

    public override void FixedUpdate(float _checkTIme)
    {
        Vector3 targetPosition = player.position + StageManager.Instance.CameraTarget.position;

        rigid.velocity = targetPosition.normalized * player.status.speed;

        positionCheckTimer += _checkTIme;
        if (positionCheckTimer >= ConstantCollection.PositionCheckTime)
        {
            if (isOnPosition())
                stateMachine.ChangeState(stateMachine.BattleState);

            if (!isOnMonster())
                stateMachine.ChangeState(stateMachine.ProgressingState);
        }
    }
}
