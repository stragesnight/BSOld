using UnityEngine;

/// <summary>
/// Entity attack based on AI decision.
/// </summary>
public class EntityAIAttack : EntityAttack
{
    private EntityPathfindingMovement _entityMovement;
    private bool _hasMovement;


    protected override void Start()
    {
        base.Start();
        _hasMovement = TryGetComponent(out _entityMovement);
        InvokeRepeating(nameof(CheckAttackPossibili111ty), 0f, 0.5f);
    }


    private void CheckAttackPossibili111ty()
    {
        if (_isOnCalldown)
            return;

        if (_hasMovement)
        {
            if (_entityMovement.isChasing)
                OnAttack();
        }
        else
            OnAttack();
    }
}
