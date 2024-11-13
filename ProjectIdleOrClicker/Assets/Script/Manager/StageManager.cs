using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    public Transform CameraTarget;

    public List<Monster> monsters;
    public float nearestMonsterDistance;
}