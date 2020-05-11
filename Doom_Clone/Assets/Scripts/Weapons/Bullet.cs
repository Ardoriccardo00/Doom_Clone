using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject damageArea;
    [SerializeField] WeaponScriptable weapon;
    [SerializeField] float speed = 10f;
    [SerializeField] bool canDamagePlayer;
    Vector3 direction;
    Rigidbody rb;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }    

    void Update()
    {
        rb.velocity = direction * speed * Time.deltaTime;
    }

    public void SetBulletDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "Player" && canDamagePlayer)
        {
            Health targetHealth = collision.transform.GetComponent<Health>();
            targetHealth.TakeDamage(weapon.weaponDamage);
            MessagesHandler.Instance.WriteMessage("Hit " + targetHealth.gameObject.name + " that took " + weapon.weaponDamage + " damage");
        }
        audioSource.Play();
        damageArea.SetActive(true);
        Destroy(gameObject, .08f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            Health targetHealth = other.transform.gameObject.GetComponent<Health>();
            targetHealth.TakeDamage(weapon.weaponDamage);
            print(targetHealth);
        }      
    }
} 