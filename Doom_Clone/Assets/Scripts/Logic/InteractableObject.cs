using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IEInteractable
{
    [SerializeField] DoorMover doorToOpen;

    private void Start()
    {
        doorToOpen = GetComponent<DoorMover>();
    }

    public void Interactable()
    {
        doorToOpen.Interactable();
        //StartCoroutine(OpenCloseDoor());
    }
}