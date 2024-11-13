using UnityEngine;

public enum MONSTERTYPE
{
    MINION,
    BOSS
}

[CreateAssetMenu(fileName = "MonsterCharacter", menuName = "ScriptableObjects/Character/Monster")]
public class MonsterCharacterSO : BaseCharacterSO
{
    [Header("Monster Data")]
    public MONSTERTYPE type;
    public StatusEffectBase[] effect;
}