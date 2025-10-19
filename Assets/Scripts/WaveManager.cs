using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Spawner spawner;

    public int waveNumber { get; set; } = 1;
    public int enemiesThisWave { get; set; } = 1;
    
    private int killCounter = 0;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void nextWave()
    {
        waveNumber++;
        enemiesThisWave *= 2;
        killCounter = 0;
        spawner.spawnWave();
    }

    public void killEnemy()
    {
        killCounter++;
        if (killCounter >= enemiesThisWave) nextWave();
    }
}
