using UnityEngine;

public class Item : MonoBehaviour
{
    public EquipmentSO? equip; // null이면 돈.
    public int level; // 돈이면 돈의 양으로 사용한다.
}