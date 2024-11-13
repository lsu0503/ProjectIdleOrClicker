using UnityEngine;

public class PlayerProgressingState : PlayerBaseState
{
    private Rigidbody rigid;
    private float positionCheckTimer;

    public PlayerProgressingState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
        rigid = player.rigid;
    }

    public override void Enter()
    {
        positionCheckTimer = 0.0f;
        animator.SetBool("isMoving", true);
        // 애니메이션 관련 코드 추가
    }

    public override void Exit()
    {
        rigid.velocity = Vector3.zero;

        // 애니메이션 관련 코드 추가
    }

    public override void FixedUpdate(float _checkTIme)
    {
        rigid.velocity = player.transform.forward * player.status.speed;
        player.transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, -4.5f, 4.5f), player.transform.position.y, player.transform.position.z);

        positionCheckTimer += _checkTIme;
        if (positionCheckTimer >= ConstantCollection.PositionCheckTime)
        {
            if (isOnMonster())
                stateMachine.ChangeState(stateMachine.PositioningState);
        }
    }
}
