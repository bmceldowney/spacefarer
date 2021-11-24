using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ship Type")]
public class ShipType : ScriptableObject
{
    public int BaseCost;
    public string Manufacturer;
    public List<Vector3> HardPoints;
    public int MaxEngineSize;
    public int Mass;
    public int ModSlots;
}
