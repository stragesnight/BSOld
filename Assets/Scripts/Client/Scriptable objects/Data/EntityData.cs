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

    // ======================================== CHARACTERISTICS ========================================

    // Max HP
    [SerializeField] private int _maxHealthPoints;
    public void SetMaxHealthPoints(int newMaxHealthPoints) { _maxHealthPoints = newMaxHealthPoints; }
    public int GetMaxHealthPoints() => _maxHealthPoints;

    // Speed
    [SerializeField] private float _speed;
    public void SetSpeed(float newSpeed) { _speed = newSpeed; }
    public float GetSpeed() => _speed;

    // =========================================== INVENTORY ===========================================

    [SerializeField] private InventorySO _inventory;
    public void SetInventory(InventorySO newInventory) { _inventory = newInventory; }
    public InventorySO GetInventory() => _inventory;

    // Held Weapon
    [SerializeField] private MeleeWeaponItemSO _heldWeapon;
    public void SetHeldWeapon(MeleeWeaponItemSO newWeapon) { _heldWeapon = newWeapon; }
    public MeleeWeaponItemSO GetHeldWeapon() => _heldWeapon;
}
