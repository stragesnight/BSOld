using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General Construction Scriptable Object class that all Buildings and Constructions will inherit from.
/// </summary>
public abstract class ConstructionSO : ScriptableObject
{
    [Header("general parameters")]
    // Rule Tile of a building used to display it.
    public RuleTile ruleTile;

    // Starting health of a construction
    public int startingHealth;

    [SerializeField] private int _width;
    [SerializeField] private int _height;

    public RequiredResource[] requiredResources;


    // Transforms RequiredResource array to Dictionary and returns it
    public Dictionary<ItemSO, int> GetRequiredResources()
    {
        Dictionary<ItemSO, int> output = new Dictionary<ItemSO, int>();

        foreach (RequiredResource r in requiredResources)
        {
            output.Add(r.resource, r.requiredAmount);
        }

        return output;
    }


    public Vector3Int[] GetConstructionPositions(Vector3Int origin)
    {
        int i = 0;
        Vector3Int[] positions = new Vector3Int[_width * _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                positions[i] = new Vector3Int(origin.x + x, origin.y + y, 0);
                i++;
            }
        }

        return positions;
    }
}


/// <summary>
/// Struct used to specify resource and amount of it required to construct building.
/// </summary>
[System.Serializable]
public struct RequiredResource
{
    public ItemSO resource;
    public int requiredAmount;
}
