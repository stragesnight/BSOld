using UnityEngine;
/// <summary>
/// Entity attack based on player input.
/// </summary>
public class EntityInputAttack : EntityAttack
{
    [SerializeField] private InputReader _inputReader;


    private void OnEnable()
    {
        _inputReader.attackAction += OnAttackInputReceived;
        _inputReader.mousePositionAction += OnTargetPositionChanged;
    }


    private void OnDisable()
    {
        _inputReader.attackAction -= OnAttackInputReceived;
        _inputReader.mousePositionAction -= OnTargetPositionChanged;
    }
}
