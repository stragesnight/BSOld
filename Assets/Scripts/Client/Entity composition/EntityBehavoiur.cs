using UnityEngine;

/// <summary>
/// General game Entity abstract class that all other Entities will inherit from.
/// </summary>
public class EntityBehavoiur : MonoBehaviour
{
    public EntityData entityData;

    // Characteristics
    public int HP;
    public float speed;


    private void Start()
    {
        LoadCharacteristics();
    }


    // Load Entity's characteristics from EntityData
    private void LoadCharacteristics()
    {
        HP = entityData.GetEntityMaxHP();
        speed = entityData.GetEntitySpeed();
    }
}
