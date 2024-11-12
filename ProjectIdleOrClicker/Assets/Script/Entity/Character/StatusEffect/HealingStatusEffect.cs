public class HealingStatusEffect : AffectStatusEffect
{
    public override void AffectEffect()
    {
        status.GetHeal(power);
    }
}
