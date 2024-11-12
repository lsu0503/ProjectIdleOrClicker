using static Cinemachine.DocumentationSortingAttribute;

public class EquipmentObj
{
    private EquipmentSO baseData;
    public int level;

    public float healthMul;
    public float defenceMul;
    public float attackMul;
    public float magicMul;
    public float SpeedMul;

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

        UpdateOption();
    }

    public void UpdateOption()
    {
        healthMul = baseData.HealthMul * (1.0f + (0.1f * level));
        defenceMul = baseData.DefenceMul * (1.0f + (0.1f * level));
        attackMul = baseData.AttackMul * (1.0f + (0.1f * level));
        magicMul = baseData.MagicMul * (1.0f + (0.1f * level));
        SpeedMul = baseData.SpeedMul;
    }

    public void OnEquip(PlayerStatus status)
    {
        this.status = status;
        EquipAffection();
    }

    public void OnUnequip()
    {
        UnequipAffection();
        status.UnequipItem(this);
    }

    public void EquipAffection()
    {
        status.health *= healthMul;
        status.defence *= defenceMul;
        status.attack *= attackMul;
        status.magic *= magicMul;
        status.speed *= SpeedMul;
    }

    public void UnequipAffection()
    {
        status.health /= healthMul;
        status.defence /= defenceMul;
        status.attack /= attackMul;
        status.magic /= magicMul;
        status.speed /= SpeedMul;
    }
}