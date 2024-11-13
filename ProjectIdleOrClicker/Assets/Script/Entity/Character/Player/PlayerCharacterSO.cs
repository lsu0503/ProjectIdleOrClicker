using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCharacter", menuName = "ScriptableObjects/Character/Player")]
public class PlayerCharacterSO : BaseCharacterSO
{
    [Header("PlayerData")]
    public float magic;
    public float speed;

    public Sprite image;
    public AnimatorOverrideController animator;
}