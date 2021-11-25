using System;
using UnityEngine;

public class SceneSetter : MonoBehaviour
{
    [SerializeField]
    EnemySpawner enemySpawner;
    [SerializeField]
    GameObject PlayerContainer;

    void Awake()
    {
        var shipPrefab = Resources.Load<Ship>("Ships/Krill"); // temp, load the real one eventually
        var weaponPrefab = Resources.Load<GameObject>("Weapons/Cannon"); // temp, load the real one eventually
        Instantiate<EnemySpawner>(enemySpawner, Vector3.up * 9, Quaternion.identity);
        var ship = Instantiate<Ship>(shipPrefab, PlayerContainer.transform);
        ship.ShipType.HardPoints.ForEach(hardPoint => {
            var weaponInstance = Instantiate<GameObject>(weaponPrefab, ship.transform);
            weaponInstance.transform.localPosition = hardPoint;
        });
    }
}
