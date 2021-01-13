using UnityEngine;

/// <summary>
/// Abstract class describing Weapons.
/// </summary>
public abstract class WeaponItemSO : ItemSO
{
    [Header("Type-specific properties")]
    public EAttackType attackType;
    public int damage;
    public float attackAnticipation;
    public float attackCalldown;
}


public enum EAttackType { MeleeCirce, MeleeLine, RangedCharge, RangedInstant }
