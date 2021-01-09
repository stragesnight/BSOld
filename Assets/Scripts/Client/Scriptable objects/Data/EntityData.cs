using UnityEngine;

/// <summary>
/// EntityData Scriptable Object class responsible for storing and transmitting data related to entities.
/// </summary>
public class EntityData : ScriptableObject
{
    // ========================================= GENERAL DATA =========================================

    // Name
    [SerializeField] private string _name;
    public void SetName(string newName) { _name = newName; }
    public string GetName() => _name;

    // Position
    [SerializeField] Vector2 _position;
    public void SetPosition(Vector2 newPosition) { _position = newPosition; }
    public Vector2 GetPosition() => _position;

    // Spawn point
    [SerializeField] Vector2 _spawnPoint;
    public void SetSpawnPoint(Vector2 newSpawnPoint) { _spawnPoint = newSpawnPoint; }
    public Vector2 GetSpawnPoint() => _spawnPoint;

    // =========================================== REACTIONS ===========================================

    // Default Reaction
    [SerializeField] private EReaction _defaultReaction;
    public void SetDefaultReaction(EReaction newDefaultReaction) { _defaultReaction = newDefaultReaction; }
    public EReaction GetDefaultReaction() => _defaultReaction;

    // Attack Reaction
    [SerializeField] private EReaction _attackReaction;
    public void SetAttackReaction(EReaction newAttackReaction) { _attackReaction = newAttackReaction; }
    public EReaction GetAttackReaction() => _attackReaction;

    // ======================================== CHARACTERISTICS ========================================

    // Max HP
    [SerializeField] private int _maxHealthPoints;
    public void SetMaxHealthPoints(int newMaxHealthPoints) { _maxHealthPoints = newMaxHealthPoints; }
    public int GetMaxHealthPoints() => _maxHealthPoints;

    // Speed
    [SerializeField] private float _speed;
    public void SetSpeed(float newSpeed) { _speed = newSpeed; }
    public float GetSpeed() => _speed;

    // Vision Radius
    [SerializeField] private float _visionRadius;
    public void SetVisionRadius(int newVisionRadius) { _visionRadius = newVisionRadius; }
    public float GetVisionRadius() => _visionRadius;

    // =========================================== INVENTORY ===========================================

    [SerializeField] private InventorySO _inventory;
    public void SetInventory(InventorySO newInventory) { _inventory = newInventory; }
    public InventorySO GetInventory() => _inventory;

    // Held Weapon
    [SerializeField] private WeaponSO _heldWeapon;
    public void SetHeldWeapon(WeaponSO newWeapon) { _heldWeapon = newWeapon; }
    public WeaponSO GetHeldWeapon() => _heldWeapon;
}


public enum EReaction { Aggressive, Neutral, Friendly }

