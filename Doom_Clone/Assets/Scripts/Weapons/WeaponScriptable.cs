﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon")]
public class WeaponScriptable : ScriptableObject
{
    public int weaponDamage;
    public float weaponRange;
    public bool isHitscan;
    public GameObject bullet;

    /*
     * add sprite
     * Add sound
     * add flare
     */
} 