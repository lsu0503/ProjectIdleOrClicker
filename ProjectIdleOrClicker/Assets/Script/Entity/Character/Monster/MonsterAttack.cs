using UnityEngine;

public class MonsterAttack : MonoBehaviour
{


    public T GetStatusEffect<T>(StatusEffectCell cell) where T : StatusEffectBase, new()
    {
        T result = new T();
        result.time = cell.time;
        result.power = cell.power;
        return result;
    }
}