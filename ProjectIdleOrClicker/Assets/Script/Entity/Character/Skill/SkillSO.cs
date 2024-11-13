using UnityEngine;

public enum SKILLTYPE
{
    ATTACK,
    SUPPORT
}

public abstract class SkillSO : ScriptableObject, IDictionaryContentBase
{
    public int id;

    public Sprite skillIcon;
    public string skillName;
    public SKILLTYPE type;
    public float power;
    public float coolTIme;

    public StatusEffectCell[] statusEffectArray;
    public GameObject SkillPrefab;

    public int Id { get { return id; }}
}
