using System;
using UnityEngine;

public class SceneSetter : StatefulBehaviour
{
    [SerializeField]
    GameObject PlayerContainer;

    protected override void HandleStateChange(GameState previous, GameState current)
    {

    }

    protected override void Awake()
    {
        base.Awake();
        var shipPrefab = Resources.Load<Ship>("Ships/Krill"); // temp, load the real one eventually
        var weaponPrefab = Resources.Load<GameObject>("Weapons/Cannon"); // temp, load the real one eventually
        var ship = Instantiate<Ship>(shipPrefab, PlayerContainer.transform);
        var weaponInstance = Instantiate<GameObject>(weaponPrefab, ship.transform);
        ship.Weapons.Add(weaponInstance.GetComponent<Cannon>());
        weaponInstance.transform.localPosition = ship.ShipType.HardPoints[0];
    }
}
