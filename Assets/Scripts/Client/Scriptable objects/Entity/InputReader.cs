using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Scriptable Object that relayers all input manipulations.
/// </summary>
public class InputReader : ScriptableObject, Controls.IEntityActions
{
    // Actions
    public Action<Vector2> moveAction;
    //...


    private Controls controls;
    // Set callbacks from Input system and enable controls
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Entity.SetCallbacks(this);
        }

        controls.Entity.Enable();
    }

    // Disable controls
    private void OnDisable()
    {
        controls.Entity.Disable();
    }


    // Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        moveAction?.Invoke(context.ReadValue<Vector2>());
    }


    //...
}
