
using System;
using UnityEngine;

public class PlayerBattleState : PlayerBaseState
{
    private float attackTimer;
    private float positionCheckTimer;

    public PlayerBattleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        player.status.ManaGauge.OnFullEvent += UseSkill;
        attackTimer = 0.0f;
        positionCheckTimer = 0.0f;

        animator.SetBool("isMoving", false);
    }

    public override void Exit()
    {
        player.status.ManaGauge.OnFullEvent -= UseSkill;
    }

    public override void FixedUpdate(float _checkTIme)
    {
        attackTimer += _checkTIme;
        if(attackTimer >= 1.0f)
        {
            attackTimer -= 1.0f;
            UseAttack();
        }

        positionCheckTimer += _checkTIme;
        if (positionCheckTimer >= ConstantCollection.PositionCheckTime)
        {
            positionCheckTimer -= ConstantCollection.PositionCheckTime;

            if (!isOnPosition())
                stateMachine.ChangeState(stateMachine.PositioningState);

            if (!isOnMonster())
                stateMachine.ChangeState(stateMachine.ProgressingState);
        }
    }

    private void UseAttack()
    {
        throw new NotImplementedException();
    }

    private void UseSkill()
    {
        stateMachine.ChangeState(stateMachine.SkillState);
    }
}
