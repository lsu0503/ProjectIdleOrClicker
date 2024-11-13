using System;
using System.Collections.Generic;
using UnityEngine;

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

    protected override void Start()
    {
        base.Start();

        ManaGauge = new Gauge(skillData.coolTIme, false);
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
    }

    public void UnequipItem(EquipmentObj equip)
    {
        int index = EquipmentList.FindIndex(idx => ReferenceEquals(idx, equip));

        if (index == -1) return;

        EquipmentList.RemoveAt(index);
    }
}
