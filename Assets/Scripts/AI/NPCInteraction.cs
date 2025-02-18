using System.Collections;
using UnityEngine;

namespace AI{
public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogueUI; // UI element to display
    public float rotationTime = 1f; // Time to rotate towards the player

    private Transform playerTransform;
    private bool isPlayerInZone; // Tracks if the player is in the trigger zone
    private NPCPatrol patrol;
    private NPCAnimation npcAnimation;

    void Start()
    {
        patrol = GetComponent<NPCPatrol>();
        npcAnimation = GetComponent<NPCAnimation>();

        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            isPlayerInZone = true; // Player is in the zone

            // Stop patrolling and show UI
            if (patrol != null)
            {
                patrol.StopPatrolling();
            }

            if (dialogueUI != null)
            {
                dialogueUI.SetActive(true);
            }

            // Rotate towards the player
            StartCoroutine(RotateTowardsPlayer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false; // Player has left the zone

            // Hide UI and resume patrolling
            if (dialogueUI != null)
            {
                dialogueUI.SetActive(false);
            }

            if (patrol != null)
            {
                patrol.ResumePatrolling();
            }
        }
    }

    private IEnumerator RotateTowardsPlayer()
    {
        Quaternion startRotation = transform.rotation;
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        float elapsedTime = 0f;
        while (elapsedTime < rotationTime)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / rotationTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }

    // Optional: Expose the player's presence in the zone to other scripts
    public bool IsPlayerInZone()
    {
        return isPlayerInZone;
    }
}
}