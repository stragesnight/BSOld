using UnityEngine;

/// <summary>
/// EntityData Scriptable Object class responsible for storing and transmitting data related to entities.
/// </summary>
public class EntityData : ScriptableObject
{
    // ========================================= GENERAL DATA =========================================

    // Name
    [SerializeField] private string entityName;
    public void SetEntityName(string newName) { entityName = newName; }
    public string GetEntityName() => entityName;

    // Position
    [SerializeField] Vector2 entityPosition;
    public void SetEntityPosition(Vector2 newPosition) { entityPosition = newPosition; }
    public Vector2 GetEntityPosition() => entityPosition;

    // Spawn point
    [SerializeField] Vector2 entitySpawnPoint;
    public void SetEntitySpawnPoint(Vector2 newSpawnPoint) { entitySpawnPoint = newSpawnPoint; }
    public Vector2 GetEntitySpawnPoint() => entitySpawnPoint;

    // ======================================== CHARACTERISTICS ========================================

    // Max HP
    [SerializeField] private int entityMaxHP;
    public void SetEntityMaxHP(int newMaxHP) { entityMaxHP = newMaxHP; }
    public int GetEntityMaxHP() => entityMaxHP;

    // Speed
    [SerializeField] private float entitySpeed;
    public void SetEntitySpeed(float newSpeed) { entitySpeed = newSpeed; }
    public float GetEntitySpeed() => entitySpeed;

    // =========================================== INVENTORY ===========================================

    [SerializeField] private InventorySO entityInventory;
    public void SetEntityInventory(InventorySO newInventory) { entityInventory = newInventory; }
    public InventorySO GetEntityInventory() => entityInventory;
}
