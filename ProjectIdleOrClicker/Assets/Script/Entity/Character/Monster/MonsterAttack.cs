using System;
using UnityEngine;

[Serializable]
public class MonsterAttack
{
    [Header("Bullet Info")]
    [SerializeField] protected float power;
    [SerializeField] protected float duration;
    [SerializeField] protected float size;
    [SerializeField] protected float speed;

    [Header("Shooting Info")]
    [SerializeField] protected Transform projSpawnPos;
    [SerializeField] protected float[] projAngleSpace;
    [SerializeField] protected int[] projsPerShot;
    [SerializeField] protected float[] shotVelTerm;
    [SerializeField] protected int[] shotsPerAttack;
    [SerializeField] protected bool isLockOn;
    [SerializeField] protected int[] projPrefsNum;
}