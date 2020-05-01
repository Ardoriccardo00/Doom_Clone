using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<WeaponScriptable> weapons = new List<WeaponScriptable>();
    public WeaponScriptable activeWeapon;

    public static Inventory Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        activeWeapon = weapons[0];
    }    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeapon = weapons[0];
            MessagesHandler.Instance.WriteMessage("weapon 1");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeapon = weapons[1];
            MessagesHandler.Instance.WriteMessage("weapon 2");
        }
    }
} 