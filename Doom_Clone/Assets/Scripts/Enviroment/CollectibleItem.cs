using System;
using UnityEngine;
using UnityEngine.Events;

public class CollectibleItem : MonoBehaviour
{
    public UnityEvent onItemCollected;

    public void ItemCollected()
    {
        onItemCollected?.Invoke();
    }
}