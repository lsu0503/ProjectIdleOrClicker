using UnityEngine;

public class Monster: MonoBehaviour
{
    protected float positionCheckTimer;
    public MonsterStatus status;

    private void Start()
    {
        positionCheckTimer = 0.0f;
    }

    private void FixedUpdate()
    {
        positionCheckTimer += Time.deltaTime;

        if(positionCheckTimer >= ConstantCollection.PositionCheckTime)
        {
            positionCheckTimer -= ConstantCollection.PositionCheckTime;

            if(StageManager.Instance.nearestMonsterDistance < Mathf.Abs(transform.position.z))
                StageManager.Instance.nearestMonsterDistance = Mathf.Abs(transform.position.z);
        }
    }
}