using System;
using System.Collections;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Transform cameraPosition;
    [SerializeField] Transform shootingPoint;
    AudioSource audioSource;
    WeaponScriptable activeWeapon;

    [Header("Ammo")]
    [SerializeField] Ammo ammoSlot;

    bool canShoot = true;

    public event EventHandler onShootEvent;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        activeWeapon = Inventory.Instance.activeWeapon;
    }    

    void Update()
    {
        activeWeapon = Inventory.Instance.activeWeapon;

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(canShoot)
                StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if(ammoSlot.GetCurrentAmmo(activeWeapon.ammoType) > 0) //if the ammo of the type of the active weapon you hold are more than 0
        {
            onShootEvent?.Invoke(this, EventArgs.Empty);
            PlayShootingSound();

            if(activeWeapon.isHitscan) //If the weapon is hitscan shoot ray
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
            else //If the weapon is not hitscan shoot the weapon bullet
            {
                GameObject bullet = Instantiate(activeWeapon.bullet, shootingPoint.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetBulletDirection(shootingPoint.transform.forward);
                Destroy(bullet, 3);
            }
        }

        yield return new WaitForSeconds(activeWeapon.weaponDelay);
        canShoot = true;
    }

    private void PlayShootingSound()
    {
        audioSource.clip = activeWeapon.shootingSound;
        audioSource.Play();
    }
} 