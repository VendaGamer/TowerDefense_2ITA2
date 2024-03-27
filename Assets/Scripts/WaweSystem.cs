using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaweSystem : MonoBehaviour
{
    [SerializeField] private const int waves = 5;
    private int currentWave;
    [SerializeField] private int StartingEnemies=10;
    private Spawner spawner;
    [SerializeField] private float spawnInterval = 4.5f;
    private int enemies;

    private void Start()
    {
        enemies = StartingEnemies;
        spawner = GetComponentInParent<Spawner>();
        StartCoroutine(SpawnEnemies());
    }
    private void NextWave()
    {
        currentWave++;
        enemies = StartingEnemies + (currentWave * 2);
    }

    private IEnumerator SpawnEnemies()
    {
        while (waves+1!=currentWave)
        {
            enemies--;
            spawner.SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);

            if (enemies==0)
            {
                spawner.SpawnBoss();
                NextWave();
            }
        }
    }
}
