using System;
using System.Collections;
using UnityEngine;
using Utils;

public class EnemySpawner : StatefulBehaviour
{
    [SerializeField]
    Enemy _enemyPrefab;
    Spawner<Enemy> _spawner;
    float _spawnInterval = 1;
    WaitForSeconds _longWait = new WaitForSeconds(5);
    WaitForSeconds _shortWait = new WaitForSeconds(0.25f);
    Camera _camera;
    Coroutine _spawnEnemies;

    public Action<int> Scored { get; set; }

    void Start()
    {
        _spawner = new Spawner<Enemy>(_enemyPrefab.GameObject, transform, 20, true);
        _camera = Camera.main;
    }

    protected override void HandleStateChange(GameState previous, GameState current)
    {
        if (current == GameState.GameOver)
        {
            StopCoroutine(_spawnEnemies);
            _spawner.Reset();
        }

        if (current == GameState.Setup)
        {
            _spawnInterval = 1;
        }

        if (current == GameState.Play)
        {
            _spawnEnemies = StartCoroutine(SpawnEnemies());
        }
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
                item.Eliminated -= AddScore;
                item.Eliminated += AddScore;
                item.Initialize(spawnLocation);
            });

            enemiesSpawned++;
            yield return _shortWait;
        }
    }

    void AddScore (int score) {
        Scored?.Invoke(score);
    }
}
