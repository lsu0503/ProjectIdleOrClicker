using UnityEngine;

public abstract class SkillSO : ScriptableObject, IDictionaryContentBase
{
    public int id;

    public Sprite skillIcon;
    public string skillName;
    public int power;

    public int Id { get { return id; }}

    public abstract void OnHit();
}
