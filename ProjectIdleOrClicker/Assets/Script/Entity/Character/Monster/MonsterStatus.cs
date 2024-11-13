using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MonsterStatus : CharacterStatus
{
    [Header("Monster Status")]
    [SerializeField] private int MonsterId;
    private MonsterCharacterSO data;

    public int difficulty;
    public float Strength;
    
    protected override void Awake()
    {
        base.Awake();
    }


}
