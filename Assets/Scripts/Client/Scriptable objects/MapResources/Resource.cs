using UnityEngine;

/// <summary>
/// General Resource Scriptable Object class that desctibes map resources.
/// </summary>
public class Resource : ScriptableObject
{
    // Icon displayed on UI elements
    public Sprite icon;
    // Sprite used to display resource on a map
    public Sprite mapSprite;
}