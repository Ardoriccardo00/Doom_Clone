using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject damageArea;
    [SerializeField] WeaponScriptable weapon;
    [SerializeField] float speed = 10f;
    Vector3 direction;
    Rigidbody rb;
    Health targetHealth;
    
    void Start()
    {
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
        if(collision.transform.tag == "Enemy")
        {
            targetHealth = collision.transform.GetComponent<Health>();
            targetHealth.TakeDamage(weapon.weaponDamage);
            MessagesHandler.Instance.WriteMessage("Hit " + targetHealth.gameObject.name + " that took " + weapon.weaponDamage + " damage");
        }
        damageArea.SetActive(true);
        Destroy(gameObject, .08f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            print(targetHealth);
            targetHealth = other.transform.gameObject.GetComponent<Health>();
            targetHealth.TakeDamage(1000);
        }      
    }
} 