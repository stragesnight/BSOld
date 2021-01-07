using UnityEngine;

/// <summary>
/// EntityData Scriptable Object class responsible for storing and transmitting data related to entities.
/// </summary>
public class EntityData : ScriptableObject
{
    // ========================================= GENERAL DATA =========================================

    // Name
    [SerializeField] private string entityName;
    public void SetName(string newName) { entityName = newName; }
    public string GetName() => entityName;

    // Position
    [SerializeField] Vector2 entityPosition;
    public void SetPosition(Vector2 newPosition) { entityPosition = newPosition; }
    public Vector2 GetPosition() => entityPosition;

    // Spawn point
    [SerializeField] Vector2 entitySpawnPoint;
    public void SetSpawnPoint(Vector2 newSpawnPoint) { entitySpawnPoint = newSpawnPoint; }
    public Vector2 GetSpawnPoint() => entitySpawnPoint;

    // ======================================== CHARACTERISTICS ========================================

    // Max HP
    [SerializeField] private int entityMaxHealthPoints;
    public void SetMaxHealthPoints(int newMaxHealthPoints) { entityMaxHealthPoints = newMaxHealthPoints; }
    public int GetMaxHealthPoints() => entityMaxHealthPoints;

    // Speed
    [SerializeField] private float entitySpeed;
    public void SetSpeed(float newSpeed) { entitySpeed = newSpeed; }
    public float GetSpeed() => entitySpeed;

    // =========================================== INVENTORY ===========================================

    [SerializeField] private InventorySO entityInventory;
    public void SetInventory(InventorySO newInventory) { entityInventory = newInventory; }
    public InventorySO GetInventory() => entityInventory;

    // Held Weapon
    [SerializeField] private MeleeWeaponItemSO entityHeldWeapon;
    public void SetHeldWeapon(MeleeWeaponItemSO newWeapon) { entityHeldWeapon = newWeapon; }
    public MeleeWeaponItemSO GetHeldWeapon() => entityHeldWeapon;
}
