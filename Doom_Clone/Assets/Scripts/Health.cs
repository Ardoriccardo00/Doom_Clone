using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }    

    void Update()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damageTaken)
    {
        currentHealth -= damageTaken;
    }

    void Die()
    {
        Destroy(gameObject);
    }
} 