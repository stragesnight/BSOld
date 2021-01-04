using System;
using UnityEngine;

/// <summary>
/// Scriptable Object that relayers all input manipulations.
/// </summary>
public class InputReader : ScriptableObject
{
    // Actions
    public Action<Vector2> moveAction;
    //...


    // Methods
    public void OnMove(Vector2 direction)
    {
        moveAction?.Invoke(direction);
    }


    //...
}
