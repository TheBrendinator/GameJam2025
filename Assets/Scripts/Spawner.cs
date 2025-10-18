using UnityEngine;

public class Spawner : MonoBehaviour
{
    public WaveManager waveManager;
    public Enemy[] enemies;

    private int spawnRadius = 40;
    private bool spawned = false;

    void Start()
    {
    }

    void Update()
    {
        if (!spawned)
        {
            spawned = true;

            for (int i = 0; i < waveManager.enemiesThisWave; i++)
            {
                spawnEnemy();
            }
        }
    }

    void spawnEnemy()
    {
        int prefabIndex =  Random.Range(0, enemies.Length);
        Enemy prefab = enemies[prefabIndex];
        Vector3 spawnPosition = getRandomPositionInCircle();
        Quaternion spawnRotation = Quaternion.identity; // No rotation yet

        Enemy newEnemy = Instantiate(prefab, spawnPosition, spawnRotation);
    }

    Vector3 getRandomPositionInCircle()
    {
        Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius;
        return new Vector3(spawnPosition.x, 0f, spawnPosition.y) + transform.position;
    }
}
