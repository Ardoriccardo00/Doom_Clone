using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] WeaponScriptable weapon;
    [SerializeField] float speed = 10f;
    Vector3 direction;
    Rigidbody rb;
    
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
        Destroy(gameObject);
        if(collision.transform.tag == "Player" || collision.transform.tag == "Enemy")
        {
            Health targetHealth = collision.transform.GetComponent<Health>();
            targetHealth.TakeDamage(weapon.weaponDamage);
            MessagesHandler.Instance.WriteMessage("Hit " + targetHealth.gameObject.name + " that took " + weapon.weaponDamage + " damage");
        }
    }
} 