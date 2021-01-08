using UnityEngine;

/// <summary>
/// Entity movement based on player's input.
/// </summary>
public class EntityInputMovement : EntityMovement
{
    [SerializeField] private InputReader _inputReader;


    private void OnEnable()
    {
        _inputReader.moveAction += OnChangeMovementDirection;
    }


    private void OnDisable()
    {
        _inputReader.moveAction -= OnChangeMovementDirection;
    }
}
