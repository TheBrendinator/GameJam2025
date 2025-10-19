using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public Spawner spawner;

    public int waveNumber { get; set; } = 1;
    public int enemiesThisWave { get; set; } = 1;
    
    private int killCounter = 0;
    private float intermissionTime = 2f;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void intermission()
    {
        StartCoroutine(intermissionWait());
    }

    IEnumerator intermissionWait()
    {
        yield return new WaitForSeconds(intermissionTime);
        nextWave();
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
        if (killCounter >= enemiesThisWave) intermission();
    }
}
