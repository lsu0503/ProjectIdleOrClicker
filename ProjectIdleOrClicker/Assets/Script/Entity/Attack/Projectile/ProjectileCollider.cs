using System;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    private Projectile proj;
    public event Action<Collider> OnCollisionEvent;

    private void OnTriggerEnter(Collider other)
    {
        OnCollisionEvent?.Invoke(other);
    }

    public void SetProj(Projectile proj)
    {
        this.proj = proj;
    }
}
