using System;
using UnityEngine;

public class SceneSetter : MonoBehaviour
{
    [SerializeField]
    GameObject PlayerContainer;

    void Awake()
    {
        var shipPrefab = Resources.Load<Ship>("Ships/Krill"); // temp, load the real one eventually
        var weaponPrefab = Resources.Load<GameObject>("Weapons/Cannon"); // temp, load the real one eventually
        var ship = Instantiate<Ship>(shipPrefab, PlayerContainer.transform);
        var weaponInstance = Instantiate<GameObject>(weaponPrefab, ship.transform);
        weaponInstance.transform.localPosition = ship.ShipType.HardPoints[0];
    }
}
