/// <summary>
/// Abstract class describing Weapons.
/// </summary>
public abstract class WeaponSO : ItemSO
{
    public EAttackType attackType;
    public float attackCalldown;
}


public enum EAttackType { MeleeCirce, MeleeCone, MeleeLine, RangedCharge, RangedInstant }