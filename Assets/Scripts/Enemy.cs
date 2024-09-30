using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player; // Asigna el GameObject del jugador en el Inspector
    public float attackRange = 2f; // Distancia de ataque del enemigo
    public float attackRate = 1f; // Frecuencia de ataques (en segundos)
    public int damage = 10; // Cantidad de da�o que causa el enemigo
    public float chaseSpeed = 3.5f; // Velocidad de persecuci�n
    public int maxHealth = 50; // Salud m�xima del enemigo
    public Transform target;

    private int currentHealth;
    private float nextAttackTime = 0f;
    private NavMeshAgent agent; // Agente de navegaci�n para que el enemigo siga al jugador
    private bool isPlayerInRange;

    void Start()
    {
        // Obtener el componente NavMeshAgent del enemigo
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (agent != null && target != null)
        {
            agent.SetDestination(target.position);
        }

        if (player != null)
        {
            // Seguir al jugador
            //agent.SetDestination(player.position);

            // Verificar si el jugador est� dentro del rango de ataque
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            isPlayerInRange = distanceToPlayer <= attackRange;

            // Atacar al jugador si est� en rango
            if (isPlayerInRange && Time.time >= nextAttackTime)
            {
                AttackPlayer();
                nextAttackTime = Time.time + attackRate;
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Enemy attacks!");

        // Obtener el script de salud del jugador y aplicarle da�o
        PlayerJump playerJump = player.GetComponent<PlayerJump>();
        if (playerJump != null)
        {
            playerJump.TakeDamage(damage);
        }
    }

    // M�todo para que el enemigo reciba da�o
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aqu� puedes a�adir la l�gica para la muerte del enemigo (animaci�n, desactivar objeto, etc.)
        Debug.Log("Enemy has been defeated!");
        Destroy(gameObject);
    }
}
