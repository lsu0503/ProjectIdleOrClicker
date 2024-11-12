using UnityEngine;

public interface ICopyable
{
    public ICopyable Copy();
}

public abstract class StatusEffectBase : IDictionaryContentBase
{
    [SerializeField] private int id;
    public float time;
    public float power;

    public CharacterStatus status;

    public int Id { get { return id; } }

    public virtual void OnEffectStart(CharacterStatus status)
    {
        this.status = status;
        status.OnTimePassedEvent += OnEffectOngoing;
    }

    public virtual void OnEffectEnd()
    {
        status.OnTimePassedEvent -= OnEffectOngoing;
        status.StatusOvered(this);
    }

    public virtual void OnEffectOngoing(float deltaTime)
    {
        time -= deltaTime;

        if (time < 0)
            OnEffectEnd();
    }
}
