using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Spawner;


public class Spawner : MonoBehaviour
{

    [SerializeField]
    private float speedInterval;

    [SerializeField] private List<SpawnData> enemyPrefabs;

    public void SpawnEnemy()
    {
        GameObject randomPrefab = GetRandomEnemy();
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
    }


    public void SpawnBoss()
    {
        foreach (SpawnData a in enemyPrefabs)
        {
            if (a.boss)
            {
                Instantiate(a.enemy, transform.position, Quaternion.identity);
                break;
            }
        }
 
    }
    GameObject GetRandomEnemy()
    {
        float rnd = Random.Range(0f, 1f);
        float sum = 0;

        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            sum += enemyPrefabs[i].probability;
            if (rnd <= sum)
            {
                return enemyPrefabs[i].enemy;
            }
        }

        return enemyPrefabs[1].enemy;
    }

    [System.Serializable]
    public class SpawnData
    {
        public GameObject enemy;
        public float probability;
        public bool boss;
    }
}
