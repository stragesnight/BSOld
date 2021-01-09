using UnityEngine;

/// <summary>
/// Entity attack based on AI decision.
/// </summary>
[RequireComponent(typeof(EntityPathfindingMovement))]
public class EntityAIAttack : EntityAttack
{
    private EntityPathfindingMovement _entityMovement;


    protected override void Start()
    {
        base.Start();
        _entityMovement = GetComponent<EntityPathfindingMovement>();

        InvokeRepeating(nameof(CheckAttackPossibili111ty), 0f, 0.5f);
    }


    private void CheckAttackPossibili111ty()
    {
        if (_isOnCalldown || !_entityMovement.isChasing)
            return;

        OnTargetPositionChanged(_entityMovement.GetTarget());
        OnAttack();
    }
}
