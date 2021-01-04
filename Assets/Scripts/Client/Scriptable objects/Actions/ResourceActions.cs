using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ResourceActions class is responsible for any Resource manipulations on the map
/// </summary>
public class ResourceActions : ScriptableObject
{
    // Actions
    public Action<Vector3Int, Resource> setResouceAtPointAction;
    public Action<Dictionary<Vector3Int, Resource>> setResourceMapAction;
    public Action<Vector3Int, int> setResourceAmountAtPointAction;
    public Action<Dictionary<Vector3Int, int>> setResourceAmountsAction;


    public void OnSetResourceAtPoint(Vector3Int position, Resource resource)
    {
        setResouceAtPointAction?.Invoke(position, resource);
        OnSetResourceAmountAtPoint(position, resource.startingAmount);
    }


    public void OnSetResourceMap(Dictionary<Vector3Int, Resource> map)
    {
        setResourceMapAction?.Invoke(map);
        OnSetResourceAmounts(GetStartResourceAmounts(map));
    }


    public void OnSetResourceAmountAtPoint(Vector3Int position, int amount)
    {
        setResourceAmountAtPointAction?.Invoke(position, amount);
    }


    public void OnSetResourceAmounts(Dictionary<Vector3Int, int> amounts)
    {
        setResourceAmountsAction?.Invoke(amounts);
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