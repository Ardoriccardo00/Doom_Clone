using System;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    //IEInteractable interactableToActivate;
    //[SerializeField] GameObject interactableToActivateObject;

    public UnityEvent onSwitchInteract;

    void Start()
    {
        //interactableToActivate = interactableToActivateObject.GetComponent<IEInteractable>();
    }    

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
                //interactableToActivate.Interactable();
                onSwitchInteract ?.Invoke();
        }
    }
} 