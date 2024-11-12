public class DamageStatusEffect : AffectStatusEffect
{
    public override void AffectEffect()
    {
        status.GetDamage(power);
    }
}