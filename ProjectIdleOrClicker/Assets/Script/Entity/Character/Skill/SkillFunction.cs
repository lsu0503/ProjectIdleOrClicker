using System;
using UnityEngine;

[Serializable]
public class StatusEffectCell
{
    public int StatusId;
    public float time;
    public float power;
}


public class SkillFunction : MonoBehaviour
{
    public SkillSO skillData;



    public T GetStatusEffect<T>(StatusEffectCell cell) where T : StatusEffectBase, new()
    {
        T result = new T();
        result.time = cell.time;
        result.power = cell.power;
        return result;
    }
}