
using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

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

    public int ReturnHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        BroadcastMessage("OnDamageTaken");
        currentHealth -= damageTaken;

        if(gameObject.tag == "Player")
        {
            PlayerStats.Instance.FadePainRedScreen();
        }
    }

    void Die()
    {
        BroadcastMessage("OnDeath");
    }
}