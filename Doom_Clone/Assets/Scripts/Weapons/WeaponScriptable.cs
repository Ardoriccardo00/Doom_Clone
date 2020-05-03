using System;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Weapon")]
public class WeaponScriptable : ScriptableObject
{
    [Header("Components")]
    public AmmoType ammoType;
    public GameObject bullet;
    public Sprite flare;
    public Sprite sprite;

    [Header("Sounds")]
    public AudioClip shootingSound;
    public AudioClip bulletSound;

    [Header("Stats")]
    public int weaponDamage;
    public float weaponRange;
    public float weaponDelay;

    public bool isHitscan;
    public int splashDamage;
} 