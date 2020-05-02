using System;
using UnityEngine;

public class KeyCardPickup : MonoBehaviour
{
    [SerializeField] KeyCard keyCard;

    private void OnTriggerEnter(Collider other)
    {
        Inventory.Instance.keycards.Add(keyCard);
        Destroy(gameObject);
    }
} 