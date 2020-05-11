using System;
using UnityEngine;

public class KeyCardPickup : MonoBehaviour
{
    [SerializeField] KeyCard keyCard;

    private void OnTriggerEnter(Collider other)
    {
        MessagesHandler.Instance.WriteMessage("You got a " + Convert.ToString(keyCard.keyCardColor) + " keycard");
        Inventory.Instance.keycards.Add(keyCard);
        Destroy(gameObject);
    }
} 