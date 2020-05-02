using System.Collections;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;
    [SerializeField] Transform shootingPoint;

    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    WeaponScriptable activeWeapon;
    bool canShoot = true;

    void Start()
    {
        activeWeapon = Inventory.Instance.activeWeapon;
    }    

    void Update()
    {
        activeWeapon = Inventory.Instance.activeWeapon;
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            print(canShoot);
            if(canShoot)
                StartCoroutine(Shoot());
        }
    }

    private void OLDShoot()
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
            GameObject bullet = Instantiate(activeWeapon.bullet, shootingPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().SetBulletDirection(shootingPoint.transform.forward);
            Destroy(bullet, 3);
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(activeWeapon.ammoType) > 0)
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
                GameObject bullet = Instantiate(activeWeapon.bullet, shootingPoint.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetBulletDirection(shootingPoint.transform.forward);
                Destroy(bullet, 3);
            }
        }
        
        yield return new WaitForSeconds(activeWeapon.weaponDelay);
        canShoot = true;
    }
} 