using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponStats", menuName = "Weapon Stats", order = 51)]
public class WeaponStats : ScriptableObject
{
    [SerializeField]
    public string weaponName;
    [SerializeField]
    public string weaponDesc;

    [SerializeField]
    public int damageType;
}
