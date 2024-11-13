
using System;
using System.Collections;
using UnityEngine;

public class PlayerSkillState : PlayerBaseState
{
    public float SkillTimer;
    private Coroutine coroutine;
    private bool isSkillUsed;

    public PlayerSkillState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        SkillTimer = 0.0f;
        isSkillUsed = false;

        animator.SetTrigger("SkillUsed");
        // 애니메이션 관련 코드 추가
    }

    public override void Exit()
    {
        // 애니메이션 관련 코드 추가
    }

    public override void FixedUpdate(float _checkTIme)
    {
        SkillTimer += _checkTIme;
        
        if(!isSkillUsed && SkillTimer >= ConstantCollection.SkillActivateTime)
        {
            isSkillUsed = true;
            ActivateSkill();
        }

        if(SkillTimer >= ConstantCollection.SkillStateDuration)
        {
            if (!isOnMonster())
                stateMachine.ChangeState(stateMachine.ProgressingState);

            else if (!isOnPosition())
                stateMachine.ChangeState(stateMachine.PositioningState);

            else
                stateMachine.ChangeState(stateMachine.BattleState);
        }
    }

    private void ActivateSkill()
    {
        
    }
}