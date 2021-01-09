using UnityEngine;
/// <summary>
/// Entity attack based on player input.
/// </summary>
public class EntityInputAttack : EntityAttack
{
    [SerializeField] private InputReader _inputReader;


    private void OnEnable()
    {
        _inputReader.attackAction += OnAttack;
    }


    private void OnDisable()
    {
        _inputReader.attackAction -= OnAttack;
    }
}
