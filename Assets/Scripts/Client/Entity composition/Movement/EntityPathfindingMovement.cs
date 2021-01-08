using UnityEngine;
using Pathfinding;

/// <summary>
/// Entity movement based on A* pathfinding algorithm.
/// </summary>
[RequireComponent(typeof(Seeker))]
public class EntityPathfindingMovement : EntityMovement
{
    [SerializeField] private float _nextWayPointThreshold = 1f;
    private Seeker _seeker;

    [SerializeField] private Transform _target;
    private Path _currentPath;
    int _currentWayPoint;


    // Get required components and invoke repeating
    protected override void Start()
    {
        base.Start();
        _seeker = GetComponent<Seeker>();
        // Path will be updated every second
        InvokeRepeating(nameof(UpdatePath), 0f, 1f);
    }


    // Start calculating new path if Seeker is not busy
    private void UpdatePath()
    {
        if (_seeker.IsDone())
            _seeker.StartPath(_rb.position, _target.position, OnPathComplete);
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
            OnChangeMovementDirection(((Vector2)_currentPath.vectorPath[_currentWayPoint] - _rb.position).normalized);
        else
            _currentPath = null;
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


    public void SetTarget(Transform newTarget) { _target = newTarget; }
    public Transform GetTarget() => _target;
}
