using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

public class Spawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> enemyPrefabs;

    [SerializeField]
    private float speedInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Instantiate(randomPrefab, transform.position, Quaternion.identity);
=======
using static Spawner;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnData> enemyPrefabs;

    public void SpawnEnemy()
    {
        var randomPrefab = GetRandomEnemy();
        Instantiate(randomPrefab,transform.position,Quaternion.identity);
    }
    public void SpawnBoss()
    {
        foreach (SpawnData a in enemyPrefabs)
        {
            if (a.boss)
            {
                Instantiate(a.enemy, transform.position, Quaternion.identity);
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
>>>>>>> Stashed changes
    }
}
