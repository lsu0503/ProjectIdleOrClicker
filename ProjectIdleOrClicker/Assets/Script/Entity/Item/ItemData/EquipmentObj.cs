using static Cinemachine.DocumentationSortingAttribute;

public class EquipmentObj
{
    public EquipmentSO baseData;
    public int level;

    public float healthMul;
    public float defenceMul;
    public float attackMul;
    public float magicMul;
    public float speedMul;

    public PlayerStatus status;

    public EquipmentObj(EquipmentSO baseData, int level)
    {
        this.baseData = baseData;
        this.level = level;

        UpdateOption();
    }

    public void EnchantEquipment()
    {
        level++;

        UnequipAffection();
        UpdateOption();
        EquipAffection();
    }

    public void UpdateOption()
    {
        healthMul = baseData.HealthMul;
        defenceMul = baseData.DefenceMul * (1.0f + (0.1f * level));
        attackMul = baseData.AttackMul * (1.0f + (0.1f * level));
        magicMul = baseData.MagicMul * (1.0f + (0.1f * level));
        speedMul = baseData.SpeedMul;
    }

    public void OnEquip(PlayerStatus status)
    {
        this.status = status;
        EquipAffection();
    }

    public void OnUnequip()
    {
        UnequipAffection();
        this.status = null;
    }

    public void EquipAffection()
    {
        status.health *= healthMul;
        status.defence *= defenceMul;
        status.attack *= attackMul;
        status.magic *= magicMul;
        status.speed *= speedMul;
    }

    public void UnequipAffection()
    {
        status.health /= healthMul;
        status.defence /= defenceMul;
        status.attack /= attackMul;
        status.magic /= magicMul;
        status.speed /= speedMul;
    }
}