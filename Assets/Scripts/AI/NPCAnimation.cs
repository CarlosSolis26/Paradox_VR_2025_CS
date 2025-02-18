using UnityEngine;

namespace AI{
public class NPCAnimation: MonoBehaviour
{
    private Animator animator;
    private NPCPatrol patrol;
    private NPCInteraction npcInteraction;

    void Start()
    {
        animator = GetComponent<Animator>();
        patrol = GetComponent<NPCPatrol>();
        npcInteraction = GetComponent<NPCInteraction>();
    }

    void Update()
    {
        // Switch between Idle and Walking animations based on movement and player presence
        var isAgentWalking = !patrol.IsWaiting() && patrol.IsMoving() && !npcInteraction.IsPlayerInZone();
        animator.SetBool("IsWalking", isAgentWalking);
    }
}
}