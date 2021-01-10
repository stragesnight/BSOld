/// <summary>
/// Abstract class describing Weapons.
/// </summary>
public abstract class WeaponItemSO : ItemSO
{
    public EAttackType attackType;
    public int damage;
    public float attackCalldown;
}


public enum EAttackType { MeleeCirce, MeleeLine, RangedCharge, RangedInstant }