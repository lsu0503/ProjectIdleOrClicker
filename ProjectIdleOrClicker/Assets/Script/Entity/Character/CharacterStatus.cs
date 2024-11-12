using System;
using UnityEngine;

[Serializable]
public class CharacterStatus
{
    [Header("Character Status")]
    public Gauge health;

    public float Defence;
    public float Attack;
    public float Speed;
}