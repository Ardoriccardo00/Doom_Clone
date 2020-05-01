using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class WeaponScriptable : ScriptableObject
{
    public float weaponDamage;
    public float weaponRange;
    public bool isHitscan;
    public GameObject bullet;

    /*
     * add sprite
     * Add sound
     * add flare
     */
} 