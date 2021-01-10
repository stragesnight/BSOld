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

    // Starting size of a building in tiles
    public Vector3Int[] positions;

    // Required resources, preferred and unwanted neighbours
    public RequiredResource[] requiredResources;
    public ConstructionSO[] preferredNeighbours;
    public ConstructionSO[] unwantedNeighbours;


    // Transforms RequiredResource array to Dictionary and returns it
    public Dictionary<ResourceItem, int> GetRequiredResources()
    {
        Dictionary<ResourceItem, int> output = new Dictionary<ResourceItem, int>();

        foreach (RequiredResource r in requiredResources)
        {
            output.Add(r.resource, r.requiredAmount);
        }

        return output;
    }
}


/// <summary>
/// Struct used to specify resource and amount of it required to construct building.
/// </summary>
[System.Serializable]
public struct RequiredResource
{
    public ResourceItem resource;
    public int requiredAmount;
}