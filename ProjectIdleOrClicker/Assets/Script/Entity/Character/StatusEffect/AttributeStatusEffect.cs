using UnityEngine;

public abstract class AttributeStatusEffect : StatusEffectBase
{
    public override void OnEffectStart(CharacterStatus status)
    {
        base.OnEffectStart(status);
        EffectAffection();
    }

    public override void OnEffectEnd()
    {
        EffectDeaffection();
        base.OnEffectEnd();
    }

    public abstract void EffectAffection();

    public abstract void EffectDeaffection();
}
