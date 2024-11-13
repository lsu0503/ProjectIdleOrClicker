using System;
using UnityEngine;

public class ProjectileAffecter : MonoBehaviour
{
    private Projectile proj;
    private ProjectileCollider projCollider;
    private ProjectileData data;
    [SerializeField] private LayerMask targetLayers;

    public void SetProj(Projectile proj)
    {
        this.proj = proj;
        projCollider = proj.projCollider;
        data = proj.data;

        projCollider.OnCollisionEvent += CheckTarget;
    }

    private void CheckTarget(Collider other)
    {
        if((targetLayers & (1 << other.gameObject.layer)) != 0)
        {
            if(data.target == PROJECTILETARGET.PLAYER)
            {
                if(other.gameObject.CompareTag("Player"))
                    CheckAffection(other);
            }

            else if(data.target == PROJECTILETARGET.MONSTER)
            {
                if(other.gameObject.CompareTag("Enemy"))
                    CheckAffection(other);
            }
        }
    }

    private void CheckAffection(Collider other)
    {
        if (data.type == PROJECTILETYPE.ATTACK)
            ProjectileAttack(other);

        else if (data.type == PROJECTILETYPE.HEAL)
            ProjectileHealing(other);
    }

    private void ProjectileAttack(Collider other)
    {
        CharacterStatus targetStatus = other.gameObject.GetComponent<CharacterStatus>();

        if (targetStatus == null) return;

        targetStatus.GetDamage(data.power);

        Destroy(gameObject);
    }

    private void ProjectileHealing(Collider other)
    {
        CharacterStatus targetStatus = other.gameObject.GetComponent<CharacterStatus>();

        if (targetStatus == null) return;

        targetStatus.GetHeal(data.power);

        Destroy(gameObject);
    }
}
