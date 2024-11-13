using System;
using UnityEngine;

public class ProjectileRicochet : MonoBehaviour
{
    private Projectile proj;
    private Rigidbody rigid;
    private ProjectileData data;

    public void SetProj(Projectile proj)
    {
        this.proj = proj;
        rigid = proj.rigid;
        data = proj.data;
    }

    private void FixedUpdate()
    {
        CheckXRicochet();
        CheckYicochet();
        CheckZRicochet();
    }

    private void CheckXRicochet()
    {
        if (data.ricochetable[0])
        {
            if (rigid.velocity.x < 0)
            {
                if (transform.position.x < -ConstantCollection.FieldXLimit)
                    rigid.velocity = new Vector3(-rigid.velocity.x, rigid.velocity.y, rigid.velocity.z);
            }
        }

        if (data.ricochetable[1])
        {
            if(rigid.velocity.x > 0)
            {
                if (transform.position.x > ConstantCollection.FieldXLimit)
                    rigid.velocity = new Vector3(-rigid.velocity.x, rigid.velocity.y, rigid.velocity.z);
            }
        }
    }

    private void CheckYicochet()
    {
        if (data.ricochetable[2])
        {
            if (rigid.velocity.y < 0)
            {
                if (transform.position.y < -ConstantCollection.FieldYLimit)
                    rigid.velocity = new Vector3(rigid.velocity.x, -rigid.velocity.y, rigid.velocity.z);
            }
        }


        if (data.ricochetable[3])
        {
            if (rigid.velocity.y > 0)
            {
                if (transform.position.y > ConstantCollection.FieldYLimit)
                    rigid.velocity = new Vector3(rigid.velocity.x, -rigid.velocity.y, rigid.velocity.z);
            }
        }
    }

    private void CheckZRicochet()
    {
        float zDifference = transform.position.z - StageManager.Instance.CameraTarget.position.z;

        if (data.ricochetable[4])
        {
            if (rigid.velocity.z < 0)
            {
                if (zDifference < -ConstantCollection.ProjectileZLimit)
                    rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, -rigid.velocity.z);
            }
        }


        if (data.ricochetable[5])
        {
            if (rigid.velocity.z > 0)
            {
                if (zDifference > ConstantCollection.ProjectileZLimit)
                    rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, -rigid.velocity.z);
            }
        }
    }
}
