public class DefenceStatusEffect : AttributeStatusEffect
{
    public override void EffectAffection()
    {
        status.defence *= power;
    }

    public override void EffectDeaffection()
    {
        status.defence /= power;
    }
}
