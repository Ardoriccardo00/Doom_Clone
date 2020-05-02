using System;
using UnityEngine;

public class Switch : MonoBehaviour
{
    IEInteractable interactableToActivate;
    [SerializeField] GameObject interactableToActivateObject;

    void Start()
    {
        interactableToActivate = interactableToActivateObject.GetComponent<IEInteractable>();
    }    

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
                interactableToActivate.Interactable();
        }
    }
} 