using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<WeaponScriptable> weapons = new List<WeaponScriptable>();
    public WeaponScriptable activeWeapon;

    public List<KeyCard> keycards = new List<KeyCard>();

    public Image weaponSpriteObject;

    int weaponToSelectNumber = 0;
    public event EventHandler<OnWeaponSwitchedEventArgs> onWeaponSwitched;

    public class OnWeaponSwitchedEventArgs : EventArgs
    {
        public int selectedWeapon = 0;
    }

    #region Singleton
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
    #endregion

    void Start()
    {
        activeWeapon = weapons[0];
        weaponSpriteObject.sprite = activeWeapon.sprite;
        onWeaponSwitched += SwitchWeapon; //switchWeapon subs to onWeaponSwitched
    }    

    void Update()
    {
        KeySwitcher();
        ScrollSwitcher();
    }

    private void ScrollSwitcher()
    {    
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(weaponToSelectNumber >= weapons.Count - 1)
            {
                weaponToSelectNumber = 0;
            }
            else
            weaponToSelectNumber++;
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(weaponToSelectNumber <= 0)
            {
                weaponToSelectNumber = weapons.Count - 1;
            }
            else
                weaponToSelectNumber--;
        }

        onWeaponSwitched?.Invoke(this, new OnWeaponSwitchedEventArgs { selectedWeapon = weaponToSelectNumber });
    }

    private void KeySwitcher()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            onWeaponSwitched?.Invoke(this, new OnWeaponSwitchedEventArgs { selectedWeapon = 0 }); //Invoca switchWeapon che e' iscritto a onweaponSwitched e passa la variablile nella classe
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            onWeaponSwitched?.Invoke(this, new OnWeaponSwitchedEventArgs { selectedWeapon = 1 });
        }
        #region locked
        /*
         * if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchWeapon(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            SwitchWeapon(5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            SwitchWeapon(6);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            SwitchWeapon(7);
        }
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            SwitchWeapon(8);
        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            SwitchWeapon(9);
        }
        */
        #endregion
    }

    private void SwitchWeapon(object sender, OnWeaponSwitchedEventArgs e)
    {
        activeWeapon = weapons[e.selectedWeapon];
        weaponSpriteObject.sprite = activeWeapon.sprite;
    }
} 