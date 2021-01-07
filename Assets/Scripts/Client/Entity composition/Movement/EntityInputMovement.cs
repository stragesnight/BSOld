using UnityEngine;

/// <summary>
/// Entity movement based on player's input.
/// </summary>
public class EntityInputMovement : EntityMovement
{
    [SerializeField] private InputReader inputReader;


    private void OnEnable()
    {
        inputReader.moveAction += OnChangeMovementDirection;
    }


    private void OnDisable()
    {
        inputReader.moveAction -= OnChangeMovementDirection;
    }
}
