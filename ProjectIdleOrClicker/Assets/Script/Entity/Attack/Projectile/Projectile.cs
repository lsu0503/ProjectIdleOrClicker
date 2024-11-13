using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileMovement movement {get; private set;}
    public ProjectileCollider projCollider {get; private set;}
    public ProjectileRicochet ricochet {get; private set;}
    public ProjectileAffecter affecter {get; private set;}
    public ProjectileData data {get; private set;}

    public Rigidbody rigid { get; private set;}

    private void Awake()
    {
        movement = GetComponent<ProjectileMovement>();
        projCollider = GetComponent<ProjectileCollider>();
        ricochet = GetComponent<ProjectileRicochet>();
        affecter = GetComponent<ProjectileAffecter>();
        data = GetComponent<ProjectileData>();
        
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        movement.SetProj(this);
        projCollider.SetProj(this);
        ricochet.SetProj(this);
        affecter.SetProj(this);
        data.SetProj(this);
    }
}
