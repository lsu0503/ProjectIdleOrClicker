using UnityEngine;

public abstract class SkillSO : ScriptableObject, IDictionaryContentBase
{
    public int id;

    public Sprite skillIcon;
    public string skillName;
    public float coolTIme;

    public GameObject SkillObject;

    public int Id { get { return id; }}
}
