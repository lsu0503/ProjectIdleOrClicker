using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Projectile proj;

    private ProjectileData data;
    private Rigidbody rigid;
    private Vector3 moveDirection;

    public void SetProj(Projectile proj)
    {
        this.proj = proj;
        data = proj.data;
        rigid = proj.rigid;
    }

    public void SetMoveDirection(Vector3 moveRotate)
    {
        moveDirection = Quaternion.Euler(moveRotate) * transform.forward;
    }

    public void ShootProjectile()
    {
        rigid.AddForce(moveDirection * data.speed, ForceMode.VelocityChange);
    }
}
