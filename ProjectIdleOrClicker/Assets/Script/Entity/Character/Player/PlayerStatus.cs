using System;
using UnityEngine;

[Serializable]
public class PlayerStatus : CharacterStatus
{
    [Header("Player Status")]
    public SkillSO skill;

    public float Magic;
    public Gauge mana;
}
