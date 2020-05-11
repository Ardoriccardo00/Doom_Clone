using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Transform shootingPoint;
    AudioSource audioSource;
    [SerializeField] WeaponScriptable activeWeapon;
    bool canShoot = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartShot()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        PlayShootingSound();

        if(activeWeapon.isHitscan) //If the weapon is hitscan shoot ray
        {
            float range = activeWeapon.weaponRange;
            int damage = activeWeapon.weaponDamage;

            RaycastHit hit;
            Ray landingRay = new Ray(shootingPoint.position, shootingPoint.transform.forward);


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

        yield return new WaitForSeconds(activeWeapon.weaponDelay);
        canShoot = true;
    }

    private void PlayShootingSound()
    {
        audioSource.clip = activeWeapon.shootingSound;
        audioSource.Play();
    }
} 