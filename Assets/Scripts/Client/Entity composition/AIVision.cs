using System;
using UnityEngine;

/// <summary>
/// Entity's ability to spot enemies.
/// </summary>
[RequireComponent(typeof(EntityBehaviour))]
public class AIVision : MonoBehaviour
{
    private EntityBehaviour _entity;
    private float _visionRadius;

    private bool _isSeeingEnemy = false;


    public Action<EntityBehaviour> enemySpotedAction;
    public Action enemyLostAction;


    private void Start()
    {
        _entity = GetComponent<EntityBehaviour>();
        _visionRadius = _entity.entityData.GetVisionRadius();

        InvokeRepeating(nameof(TrySpotEnemy), 0f, 1f);
    }


    private void TrySpotEnemy()
    {
        // Get all Colliders in radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _visionRadius);

        foreach (Collider2D hit in hits)
        {
            // Get checked entity
            if (hit.TryGetComponent(out EntityBehaviour hitEntity))
            {
                // Get Reaction of a checked entity
                EReaction checkedEntityReaction = hitEntity.currentReaction;
                // If Entity is not caster and if their reaction are different
                if (hit.gameObject != gameObject && _entity.currentReaction != checkedEntityReaction)
                {
                    // If found enemy
                    if (!_isSeeingEnemy)
                    {
                        print("enemy found");
                        enemySpotedAction?.Invoke(hitEntity);
                        _isSeeingEnemy = true;
                    }

                    return;
                }
            }
        }

        // If seen enemy but lost him
        if (_isSeeingEnemy)
        {
            print("enemy lost");
            enemyLostAction?.Invoke();
            _isSeeingEnemy = false;
        }
    }
}
