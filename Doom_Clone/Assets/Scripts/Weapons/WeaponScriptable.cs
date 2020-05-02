using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class WeaponScriptable : ScriptableObject
{
    public AmmoType ammoType;
    public int weaponDamage;
    public float weaponRange;
    public bool isHitscan;
    public GameObject bullet;
    public int splashDamage;
    public float weaponDelay;

    /*
     * add sprite
     * Add sound
     * add flare
     */
} 