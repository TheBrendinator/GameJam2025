using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public WaveManager waveManager;
    public NavMeshAgent agent;
    public Rigidbody body;
    public Player player;
    public Billboard billboard;
    public HealthBar healthBar;

    public int health { get; set; } = 100;
    private float detectionRange = 5f;
    private float knockbackForce = 15f;

    void Start()
    {
        agent.speed = Random.Range(1, 15);
        healthBar.setMaxHealth(health);
    }

    void Update()
    {
        if (player == null) return;
        if (!agent.enabled) return;
        agent.SetDestination(player.transform.position);

        if (!Input.GetMouseButtonDown(0)) return;

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > detectionRange) return;
        takeDamage();
    }

    void takeDamage()
    {
        health -= player.damage;
        healthBar.setHealth(health);
        if (health <= 0)
        {
            die();
            return;
        }
        agent.enabled = false;
        body.isKinematic = false;
        body.AddForce(player.orientation.forward * knockbackForce, ForceMode.Impulse);
        StartCoroutine(restartNavigation());
    }

    IEnumerator restartNavigation()
    {
        yield return new WaitForSeconds(2f);
        body.isKinematic = true;
        agent.enabled = true;
    }

    void die()
    {
        waveManager.killEnemy();
        Destroy(gameObject);
    }
}
