using UnityEngine;
using Pathfinding;

/// <summary>
/// Entity movement based on A* pathfinding algorithm.
/// </summary>
[RequireComponent(typeof(Seeker), typeof(AIVision))]
public class EntityPathfindingMovement : EntityMovement
{
    [SerializeField] private EDefaultBehaviour _defaultBehaviour;
    [SerializeField] private EChaseBehaviour _chaseBehaviour;
    [SerializeField] private float _nextWayPointThreshold = 1f;

    private Seeker _seeker;
    private AIVision _vision;
    private float _visionRadius;

    private EntityBehaviour _entityTarget;
    private Vector2 _target;
    private Path _currentPath;
    int _currentWayPoint;

    private bool _isReachedEndOfThePath = true;


    // Get required components and invoke repeating
    protected override void Start()
    {
        base.Start();
        _seeker = GetComponent<Seeker>();
        _vision = GetComponent<AIVision>();

        _visionRadius = _entity.entityData.GetVisionRadius();

        _vision.enemySpotedAction += SetEntityTarget;
        _vision.enemyLostAction += ClearEntityTarget;

        // Path will be updated every second
        InvokeRepeating(nameof(UpdatePath), 0f, 1f);
    }


    private void OnDisable()
    {
        _vision.enemySpotedAction -= SetEntityTarget;
        _vision.enemyLostAction -= ClearEntityTarget;
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
        Vector2 target = Vector2.zero;
        // If Entity has other Entity as Target
        if (_entityTarget)
            // Choose path depending on behaviour
            switch (_chaseBehaviour)
            {
                case EChaseBehaviour.Chase:
                    target = _entityTarget.transform.position;
                    break;
                case EChaseBehaviour.RunAway:
                    target = transform.position + (transform.position - _entityTarget.transform.position);
                    break;
            }

        // If Entity has no other Enity target and have completed current path
        else if (!_entityTarget && _isReachedEndOfThePath)
        {
            // Choose path depending on behaviour
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


    private void SetEntityTarget(EntityBehaviour entityTarget) { _entityTarget = entityTarget; }
    private void ClearEntityTarget() { _entityTarget = null; }


    internal enum EDefaultBehaviour { Idle, Patrol }
    internal enum EChaseBehaviour { Chase, RunAway }
}
