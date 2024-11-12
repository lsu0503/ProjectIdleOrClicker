public class AttackStatusEffect : AttributeStatusEffect
{
    public override void EffectAffection()
    {
        status.attack *= power;
    }

    public override void EffectDeaffection()
    {
        status.attack /= power;
    }
}