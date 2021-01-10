using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Scriptable Object that relayers all input manipulations.
/// </summary>
public class InputReader : ScriptableObject, Controls.IEntityActions, Controls.IInventoryActions
{
    // Entity Actions
    public Action<Vector2> moveAction;
    public Action attackAction;
    public Action<Vector2> mousePositionAction;

    // Inventory Actions
    public Action<int> inventorySlotAction;
    //...


    private Controls controls;
    // Set callbacks from Input system and enable controls
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new Controls();
            controls.Entity.SetCallbacks(this);
            controls.Inventory.SetCallbacks(this);
        }

        controls.Entity.Enable();
        controls.Inventory.Enable();
    }

    // Disable controls
    private void OnDisable()
    {
        controls.Entity.Disable();
        controls.Inventory.Disable();
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


    public void OnInventorySlot1(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(0); }
    public void OnInventorySlot2(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(1); }
    public void OnInventorySlot3(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(2); }
    public void OnInventorySlot4(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(3); }
    public void OnInventorySlot5(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(4); }
    public void OnInventorySlot6(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(5); }
    public void OnInventorySlot7(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(6); }
    public void OnInventorySlot8(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(7); }
    public void OnInventorySlot9(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(8); }
    public void OnInventorySlot10(InputAction.CallbackContext context) { if (context.phase == InputActionPhase.Performed) inventorySlotAction?.Invoke(9); }
    //...
}
