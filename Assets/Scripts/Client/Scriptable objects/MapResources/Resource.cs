using UnityEngine;

/// <summary>
/// General Resource Scriptable Object class that desctibes map resources.
/// </summary>
public class Resource : ScriptableObject
{
    // RuleTile that Resource is represented by
    public RuleTile ruleTile;
    // Starting amount of resource
    public int startingAmount;
}