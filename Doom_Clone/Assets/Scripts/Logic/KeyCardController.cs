using System;
using System.Collections;
using UnityEngine;

public class KeyCardController : MonoBehaviour
{
    IEInteractable doorToMove;
    [SerializeField] GameObject doorToMoveObject;
    [SerializeField] KeyCardColor keyColor;

    private void Start()
    {
        doorToMove = doorToMoveObject.GetComponent<IEInteractable>();
    }

    private void OnTriggerStay(Collider other)
    {
        bool gotRightCard = false;
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                foreach(KeyCard card in Inventory.Instance.keycards)
                {
                    if(card.keyCardColor == keyColor)
                    {
                        MessagesHandler.Instance.WriteMessage("openingDoor");
                        doorToMove.Interactable();
                        gotRightCard = true;
                    }
                }

                if(!gotRightCard)
                {
                    MessagesHandler.Instance.WriteMessage("You need the right keycard");
                }
            }            
        }
    }
} 