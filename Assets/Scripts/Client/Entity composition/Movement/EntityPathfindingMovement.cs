using UnityEngine;
using Pathfinding;

/// <summary>
/// Entity movement based on A* pathfinding algorithm.
/// </summary>
[RequireComponent(typeof(Seeker))]
public class EntityPathfindingMovement : EntityMovement
{
    [SerializeField] private float _nextWayPointThreshold = 1f;
    [SerializeField] private EDefaultBehaviour _defaultBehaviour;
    [SerializeField] private EChaseBehaviour _chaseBehaviour;
    private float _visionRadius;
    private Seeker _seeker;

    [HideInInspector] private Vector2 _target;
    public Vector2 GetTarget() => _target;
    private Path _currentPath;
    int _currentWayPoint;

    private bool _isReachedEndOfThePath = true;
    [HideInInspector] public bool isChasing = false;


    // Get required components and invoke repeating
    protected override void Start()
    {
        base.Start();
        _visionRadius = _entity.entityData.GetVisionRadius();
        _seeker = GetComponent<Seeker>();
        // Path will be updated every second
        InvokeRepeating(nameof(UpdatePath), 0f, 1f);
    }


    // Start calculating new path
    private void UpdatePath()
    {
        _target = GetNextPathTarget();

        // Start Path if Seeker is not busy and currently have target
        if (_seeker.IsDone() && _target != Vector2.zero)
            _seeker.StartPath(_rb.position, _target, OnPathComplete);
    }


    // Called when Seeker is done calculating path
    private void OnPathComplete(Path path)
    {
        if (path.error) 
            return;

        _currentPath = path;
        _currentWayPoint = 0;
    }


    // Increment current waypoint index and change movement direction
    private void UpdateWayPoint()
    {
        _currentWayPoint++;
        if (_currentWayPoint < _currentPath.vectorPath.Count)
        {
            _isReachedEndOfThePath = false;
            OnChangeMovementDirection(((Vector2)_currentPath.vectorPath[_currentWayPoint] - _rb.position).normalized);
        }
        else
        {
            _isReachedEndOfThePath = true;
            _currentPath = null;
        }
    }


    // Move Entity in direction of current waypoint
    protected override void FixedUpdate()
    {
        // Check if Entity has path
        if (_currentPath == null) 
            return;

        // Calculate distance to current waypoint
        float distanceToWayPoint = Vector2.Distance(_currentPath.vectorPath[_currentWayPoint], _rb.position);

        // update waypoint if threshold was reached
        if (distanceToWayPoint < _nextWayPointThreshold)
            UpdateWayPoint();

        // Move Entity
        base.FixedUpdate();
    }


    private Vector2 GetNextPathTarget()
    {
        isChasing = TryGetChasingTarget(out Vector2 target);

        if (!isChasing && _isReachedEndOfThePath)
        {
            switch (_defaultBehaviour)
            {
                case EDefaultBehaviour.Patrol:
                    target = GetNextPatrolTarget();
                    break;
                case EDefaultBehaviour.Idle:
                    break;
            }
        }

        return target;
    }


    private Vector2 GetNextPatrolTarget()
    {
        // Get 2 random values from -1 to 1
        float patrolX = Random.Range(-1f, 1f);
        float patrolY = Random.Range(-1f, 1f);

        // Normalized vector multiplied by vision radius
        Vector2 patrolTarget = new Vector2(patrolX, patrolY).normalized * _visionRadius;
        // Add current position to it
        patrolTarget += (Vector2)transform.position;

        return patrolTarget;
    }


    private bool TryGetChasingTarget(out Vector2 target)
    {
        // Get all Colliders in radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _visionRadius);

        foreach (Collider2D hit in hits)
        {
            // Get checked entity
            bool isEntity = hit.TryGetComponent(out EntityBehaviour hitEntity);

            if (isEntity)
            {
                // Get Reaction of a checked entity
                EReaction checkedEntityReaction = hitEntity.currentReaction;
                // If Entity is not caster and if their reaction are different
                if (hit.gameObject != gameObject && _entity.currentReaction != checkedEntityReaction)
                {
                    switch (_chaseBehaviour)
                    {
                        case EChaseBehaviour.Chase:
                            target = hit.transform.position;
                            break;
                        case EChaseBehaviour.RunAway:
                            target = transform.position + (transform.position - hit.transform.position);
                            break;
                        default:
                            target = Vector2.zero;
                            break;
                    }
                    return true;
                }
            }
        }

        target = Vector2.zero;
        return false;
    }


    internal enum EDefaultBehaviour { Idle, Patrol }
    internal enum EChaseBehaviour { Chase, RunAway }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _visionRadius);
    }
}
