using UnityEngine;

/// <summary>
/// Entity attack based on AI decision.
/// </summary>
[RequireComponent(typeof(AIVision))]
public class EntityAIAttack : EntityAttack
{
    private AIVision _vision;
    private EntityBehaviour _entityTarget;


    protected override void Start()
    {
        base.Start();

        _vision = GetComponent<AIVision>();
        _vision.enemySpotedAction += SetEntityTarget;
        _vision.enemyLostAction += ClearEntityTarget;

        InvokeRepeating(nameof(CheckAttackPossibility), 0f, 0.5f);
    }


    private void OnDisable()
    {
        _vision.enemySpotedAction -= SetEntityTarget;
        _vision.enemyLostAction -= ClearEntityTarget;
    }


    private void CheckAttackPossibility()
    {
        if (_isOnCalldown || !_entityTarget)
            return;

        OnTargetPositionChanged(_entityTarget.transform.position);
        OnAttack();
    }


    private void SetEntityTarget(EntityBehaviour entityTarget) { _entityTarget = entityTarget; }
    private void ClearEntityTarget() { _entityTarget = null; }
}
