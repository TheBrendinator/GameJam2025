using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health { get; set; } = 100;
    public NavMeshAgent agent;
    public TestPlayer player;

    void Start()
    {
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    void TakeDamage() {
        health -= player.damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
