using System;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;
    [SerializeField] Transform shootingPoint;
    Inventory inventory;
    WeaponScriptable activeWeapon;

    void Start()
    {
        activeWeapon = Inventory.Instance.activeWeapon;
    }    

    void Update()
    {
        activeWeapon = Inventory.Instance.activeWeapon;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(activeWeapon.isHitscan)
        {
            float range = activeWeapon.weaponRange;
            int damage = activeWeapon.weaponDamage;

            RaycastHit hit;
            Ray landingRay = new Ray(cameraPosition.position, cameraPosition.transform.forward);

            if(Physics.Raycast(landingRay, out hit, range))
            {
                if(hit.transform.tag == "Enemy")
                {
                    MessagesHandler.Instance.WriteMessage("hit " + hit.transform.name + " with " + activeWeapon.weaponDamage);
                    hit.transform.GetComponent<Health>().TakeDamage(damage);
                }
            }
        }

        else
        {
            print(activeWeapon.isHitscan);
            GameObject bullet = Instantiate(activeWeapon.bullet, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetBulletDirection(shootingPoint.transform.forward);
            Destroy(bullet, 3);
        }
    }
} 