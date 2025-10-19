using UnityEngine;

public class Spawner : MonoBehaviour
{
    public WaveManager waveManager;
    public Enemy[] enemies;
    public Player player;

    private int spawnRadius = 40;

    void Start()
    {
        spawnWave();
    }

    void Update()
    {
    }

    public void spawnWave()
    {
        for (int i = 0; i < waveManager.enemiesThisWave; i++)
            spawnEnemy();
    }

    void spawnEnemy()
    {
        
        int enemyIndex =  Random.Range(0, enemies.Length);
        Enemy enemy = enemies[enemyIndex];
        Vector3 spawnPosition = getRandomPositionInCircle();
        Quaternion spawnRotation = Quaternion.identity; // No rotation yet

        Enemy newEnemy = Instantiate(enemy, spawnPosition, spawnRotation);

        if (player != null) newEnemy.player = player;
        if (waveManager != null) newEnemy.waveManager = waveManager;
    }

    Vector3 getRandomPositionInCircle()
    {
        Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;
        return new Vector3(spawnPosition.x, 0f, spawnPosition.y) + transform.position;
    }
}
