using UnityEngine;

public class Spawner : MonoBehaviour
{
    public WaveManager waveManager;
    public Enemy[] enemies;
    public Player player;
    public Transform cam;

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
        newEnemy.billboard.cam = cam;
    }

    Vector3 getRandomPositionInCircle()
    {
        Vector2 positionInCircle = Vector2.zero;
        Vector3 spawnPosition = Vector3.zero;
        float distance = 0f;
        do
        {
            positionInCircle = Random.insideUnitCircle * spawnRadius;
            spawnPosition = new Vector3(positionInCircle.x, 0f, positionInCircle.y);
            distance = Vector3.Distance(spawnPosition, player.transform.position);
        }
        while (distance < 10f);
        return spawnPosition + transform.position;
    }
}
