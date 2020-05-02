using System;
using UnityEngine;

public class HazardousFloor : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float maxCounter = 5;
    float counter;

    void Start()
    {
        counter = maxCounter;
    }

    private void OnTriggerStay(Collider other)
    {     
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Health targetHealth = other.gameObject.GetComponent<Health>();
            counter -= Time.deltaTime/.5f;

            if(counter <= 0)
            {
                targetHealth.TakeDamage(damage);
                counter = maxCounter;
            }        
        }
    }
} 