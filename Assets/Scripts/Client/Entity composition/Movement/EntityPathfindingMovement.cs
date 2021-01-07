using UnityEngine;
using Pathfinding;

/// <summary>
/// Entity movement based on A* pathfinding algorithm.
/// </summary>
[RequireComponent(typeof(Seeker))]
public class EntityPathfindingMovement : EntityMovement
{
    [SerializeField] private float nextWayPointThreshold = 1f;
    private Seeker seeker;

    [SerializeField] private Transform target;
    private Path currentPath;
    int currentWayPoint;


    // Get required components and invoke repeating
    protected override void Start()
    {
        base.Start();
        seeker = GetComponent<Seeker>();
        // Path will be updated every second
        InvokeRepeating(nameof(UpdatePath), 0f, 1f);
    }


    // Start calculating new path if Seeker is not busy
    private void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }


    // Called when Seeker is done calculating path
    private void OnPathComplete(Path path)
    {
        if (path.error) 
            return;

        currentPath = path;
        currentWayPoint = 0;
    }


    // Increment current waypoint index and change movement direction
    private void UpdateWayPoint()
    {
        currentWayPoint++;
        if (currentWayPoint < currentPath.vectorPath.Count)
            OnChangeMovementDirection(((Vector2)currentPath.vectorPath[currentWayPoint] - rb.position).normalized);
        else
            currentPath = null;
    }


    // Move Entity in direction of current waypoint
    protected override void FixedUpdate()
    {
        // Check if Entity has path
        if (currentPath == null) 
            return;

        // Calculate distance to current waypoint
        float distanceToWayPoint = Vector2.Distance(currentPath.vectorPath[currentWayPoint], rb.position);

        // update waypoint if threshold was reached
        if (distanceToWayPoint < nextWayPointThreshold)
            UpdateWayPoint();

        // Move Entity
        base.FixedUpdate();
    }


    public void SetTarget(Transform newTarget) { target = newTarget; }
    public Transform GetTarget() => target;
}
