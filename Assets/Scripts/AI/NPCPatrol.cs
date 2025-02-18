using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace AI{
public class NPCPatrol : MonoBehaviour
{
    public Transform[] patrolPoints; // Array of patrol points
    public float waitTime = 3f; // Time to wait at each point

    private NavMeshAgent agent;
    private int currentPoint;
    private bool isWaiting;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
    }

    private void Update()
    {
        if (!isWaiting && HasReachedDestination())
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    private IEnumerator WaitAtPoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        
        MoveToNextPoint();
        isWaiting = false;
    }

    private void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0) return;
        
        agent.destination = patrolPoints[currentPoint].position;
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }

    private bool HasReachedDestination()
    {
        var isCloseToDestination = !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
        var hasStoppedMoving = !agent.hasPath || agent.velocity.magnitude == 0f;

        return isCloseToDestination && hasStoppedMoving;
    }

    public void StopPatrolling()
    {
        agent.isStopped = true;
    }

    public void ResumePatrolling()
    {
        agent.isStopped = false;
        MoveToNextPoint();
    }

    // Expose the isWaiting flag to other scripts
    public bool IsWaiting()
    {
        return isWaiting;
    }

    // Expose whether the NPC is moving
    public bool IsMoving()
    {
        return agent.velocity.magnitude > 0.1f;
    }
}
}