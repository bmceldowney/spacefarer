using System.Collections;
using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    /*
    The goals of this stage:
        1. do not let more than the right amount of enemies past you
        2. do not get hit by any enemies
        3. survive until the enemies stop coming
    */
    [SerializeField]
    EnemySpawner enemySpawner;
    [SerializeField]
    private int _allowedEnemiesPast;
    private int _enemiesPast;

    public Action StageFailed;

    void Awake()
    {
        Instantiate<EnemySpawner>(enemySpawner, Vector3.up * 9, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        _enemiesPast = 0;
        enemySpawner.EnemyPassed += () => {
            _enemiesPast++;
            Debug.Log($"the enemy count is {_enemiesPast.ToString()} / {_allowedEnemiesPast}");
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemiesPast >= _allowedEnemiesPast) {
            
            StageFailed?.Invoke();
        }
    }

    
}
