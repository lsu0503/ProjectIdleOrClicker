using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public Transform CameraTarget;

    public List<Monster> monsters;
    public float nearestMonsterDistance;

    private void FixedUpdate()
    {
        if (monsters.Count > 0)
        {
            nearestMonsterDistance = monsters[0].transform.position.z;

            for (int i = 1; i < monsters.Count; i++)
            {
                if (nearestMonsterDistance < monsters[i].transform.position.z)
                    nearestMonsterDistance = monsters[i].transform.position.z;
            }
        }

        else
            nearestMonsterDistance = float.MinValue;
    }
}