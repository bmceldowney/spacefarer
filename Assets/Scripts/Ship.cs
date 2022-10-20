using UnityEngine;
using System.Collections.Generic;

public class Ship : StatefulBehaviour
{
    public ShipType ShipType;
    public List<IFireable> Weapons;

    bool _fireWeapons = false;

    protected override void Awake()
    {
        base.Awake();
        Weapons = new List<IFireable>();
    }

    void Update()
    {
        if (_fireWeapons)
        {
            Weapons.ForEach(weapon => weapon.Fire());
        }
    }

    protected override void HandleStateChange(GameState previous, GameState current)
    {
        _fireWeapons = current == GameState.Play;
    }
}
