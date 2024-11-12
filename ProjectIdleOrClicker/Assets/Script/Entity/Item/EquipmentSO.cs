using UnityEngine;

public class EquipmentSO : ScriptableObject, IDictionaryContentBase
{
    public int id;

    public Sprite ItemImage;
    public string Name;

    public float HealthMul;
    public float DefenceMul;
    public float AttackMul;
    public float MagicMul;
    public float SpeedMul;

    public int Id { get { return id; } }
}
