using System.Collections;
using UnityEngine;
using Utils;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Enemy _enemyPrefab;
    Spawner<Enemy> _spawner;
    float _spawnInterval = 1;
    WaitForSeconds _longWait = new WaitForSeconds(5);
    WaitForSeconds _shortWait = new WaitForSeconds(0.25f);

    void Start()
    {
        _spawner = new Spawner<Enemy>(_enemyPrefab.GameObject, transform, 20);
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            StartCoroutine(SpawnEnemyGroup(_spawnInterval));
            yield return _longWait;
            _spawnInterval++;
        }
    }

    IEnumerator SpawnEnemyGroup(float enemyCount)
    {
        int enemiesSpawned = 0;
        while(enemiesSpawned < enemyCount)
        {
            _spawner.Spawn(item => item.gameObject.transform.Translate(Random.Range(-8, 8), 0f, 0f));
            enemiesSpawned++;
            yield return _shortWait;
        }
    }
}
