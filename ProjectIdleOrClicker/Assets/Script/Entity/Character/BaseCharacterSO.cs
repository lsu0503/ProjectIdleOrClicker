using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character/Base")]
public class BaseCharacterSO : ScriptableObject, IDictionaryContentBase
{
    [SerializeField] private int id;

    public float health;
    public float defence;
    public float attack;

    public int Id { get { return id; } }
}