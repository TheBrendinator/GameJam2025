using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Behaviour waveManager;
    public Enemy[] enemies;

    private int spawnRadius = 50;

    void Start()
    {
    }

    void Update()
    {
        spawnEnemy();
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
