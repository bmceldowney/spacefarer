using System;
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
    Camera _camera;

    public Action EnemyPassed { get; set; }

    void Start()
    {
        _spawner = new Spawner<Enemy>(_enemyPrefab.GameObject, transform, 20, true);
        _camera = Camera.main;
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
            Vector3 spawnLocation = _camera.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.1f, 0.9f), 1.1f, -_camera.transform.position.z));

            _spawner.Spawn(item => {
                item.DoDamage -= DoDamage;
                item.DoDamage += DoDamage;
                item.Initialize(spawnLocation);
            });

            enemiesSpawned++;
            yield return _shortWait;
        }
    }

    void DoDamage () {
        EnemyPassed?.Invoke();
    }
}
