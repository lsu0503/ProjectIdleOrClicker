using UnityEngine;

public enum PROJECTILETARGET
{
    PLAYER,
    MONSTER
}

public enum PROJECTILETYPE
{
    ATTACK,
    HEAL
}

public class ProjectileData : MonoBehaviour
{
    private Projectile proj;
    public PROJECTILETARGET target;
    public PROJECTILETYPE type;
    public float power;
    public float speed;
    public float time;
    public bool[] ricochetable = new bool[6]; // LEFT, RIGHT, UP, DDOWN, BACK, FOWARD [기준: 플레이어 시점]

    public void SetProj(Projectile proj)
    {
        this.proj = proj;
    }
}