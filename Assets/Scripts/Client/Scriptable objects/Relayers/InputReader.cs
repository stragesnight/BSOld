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
    public Action attackAction;
    public Action<Vector2> mousePositionAction;
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


    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            attackAction?.Invoke();
    }


    public void OnMousePosition(InputAction.CallbackContext context)
    {
        mousePositionAction?.Invoke(Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()));
    }


    //...
}
