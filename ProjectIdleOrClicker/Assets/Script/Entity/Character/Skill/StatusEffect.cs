public abstract class StatusEffect
{
    public int turn;
    public int power;

    public abstract void OnEffectStart();
    public abstract void OnEffectEnd();
    public abstract void OnEffectOngoing();
}