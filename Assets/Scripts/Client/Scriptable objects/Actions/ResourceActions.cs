using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ResourceActions class is responsible for any Resource manipulations on the map
/// </summary>
public class ResourceActions : ScriptableObject
{
    // Actions
    public Action<Vector3Int, ResourceItem> setResouceAtPointAction;
    public Action<Dictionary<Vector3Int, ResourceItem>> setResourceMapAction;
    public Action<Vector3Int, int> setResourceAmountAtPointAction;
    public Action<Dictionary<Vector3Int, int>> setResourceAmountsAction;


    public void OnSetResourceAtPoint(Vector3Int position, ResourceItem resource)
    {
        setResouceAtPointAction?.Invoke(position, resource);
    }


    public void OnSetResourceMap(Dictionary<Vector3Int, ResourceItem> map)
    {
        setResourceMapAction?.Invoke(map);
    }


    public void OnSetResourceAmountAtPoint(Vector3Int position, int amount)
    {
        setResourceAmountAtPointAction?.Invoke(position, amount);
    }


    public void OnSetResourceAmounts(Dictionary<Vector3Int, int> amounts)
    {
        setResourceAmountsAction?.Invoke(amounts);
    }
}