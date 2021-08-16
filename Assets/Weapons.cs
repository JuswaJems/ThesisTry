using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapons : ScriptableObject
{
    public Sprite currentWeaponSpr;

    public float fireRate = 1;

}
