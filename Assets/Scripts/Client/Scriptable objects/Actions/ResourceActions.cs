using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ResourceActions class is responsible for any Resource manipulations on the map
/// </summary>
public class ResourceActions : ScriptableObject
{
    // Actions
    public Action<Vector3Int, Resource> OnSetResourceAtPoint;
    public Action<Dictionary<Vector3Int, Resource>> OnSetResourceMap;
    public Action<Vector3Int, int> OnSetResourceAmountAtPoint;
    public Action<Dictionary<Vector3Int, int>> OnSetResourceAmounts;


    public void SetResourceAtPoint(Vector3Int position, Resource resource)
    {
        OnSetResourceAtPoint?.Invoke(position, resource);
        SetResourceAmountAtPoint(position, resource.startingAmount);
    }


    public void SetResourceMap(Dictionary<Vector3Int, Resource> map)
    {
        OnSetResourceMap?.Invoke(map);
        SetResourceAmounts(GetStartResourceAmounts(map));
    }


    public void SetResourceAmountAtPoint(Vector3Int position, int amount)
    {
        OnSetResourceAmountAtPoint?.Invoke(position, amount);
    }


    public void SetResourceAmounts(Dictionary<Vector3Int, int> amounts)
    {
        OnSetResourceAmounts?.Invoke(amounts);
    }


    private Dictionary<Vector3Int, int> GetStartResourceAmounts(Dictionary<Vector3Int, Resource> map)
    {
        Dictionary<Vector3Int, int> startingAmounts = new Dictionary<Vector3Int, int>();

        foreach (Vector3Int position in map.Keys)
        {
            startingAmounts.Add(position, map[position].startingAmount);
        }

        return startingAmounts;
    }
}