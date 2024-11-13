using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

[Serializable]
public class PlayerStatus : CharacterStatus
{
    [Header("Player Status")]
    public PlayerCharacterSO data;
    public SkillSO skillData;

    public float magic;
    public float speed;

    public Gauge ManaGauge;

    protected List<EquipmentObj> EquipmentList = new List<EquipmentObj>();

    public event Action<EquipmentObj> OnEquipEvent;
    public event Action<int> OnUnequipEvent;
    public event Action<int> OnEnchantEvent;

    protected override void Awake()
    {
        health = data.health;
        defence = data.defence;
        attack = data.attack;
        magic = data.magic;
        speed = data.speed;

        //ManaGauge = new Gauge(skillData.coolTIme, false);
        ManaGauge = new Gauge(100.0f, false);
        base.Awake();

        GameManager.Instance.playersData.Add(this);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        ManaGauge.ChangeGauge(Time.deltaTime);
    }

    public void EquipItem(EquipmentObj equip)
    {
        EquipmentList.Add(equip);
        equip.OnEquip(this);

        OnEquipEvent?.Invoke(equip);
    }

    public void UnequipItem(int index)
    {
        EquipmentList[index].OnUnequip();
        EquipmentList.RemoveAt(index);

        OnUnequipEvent?.Invoke(index);
    }

    public void EnchantItem(int index)
    {
        EquipmentList[index].EnchantEquipment();
        OnEnchantEvent?.Invoke(index);
    }
}
