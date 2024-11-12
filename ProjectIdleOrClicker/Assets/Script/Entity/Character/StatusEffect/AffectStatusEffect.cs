using Unity.VisualScripting;
using UnityEngine;

public abstract class AffectStatusEffect : StatusEffectBase
{
    [SerializeField] protected float affectionRate;
    protected float affectedTime;

    public override void OnEffectStart(CharacterStatus status)
    {
        base.OnEffectStart(status);
        affectedTime = Time.time;
    }

    public override void OnEffectOngoing(float deltaTime)
    {
        base.OnEffectOngoing(deltaTime);

        if (Time.time - affectedTime >= affectionRate)
        {
            affectedTime = Time.time;
            AffectEffect();
        }
    }

    public abstract void AffectEffect();
}
