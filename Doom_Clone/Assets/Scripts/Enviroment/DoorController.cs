using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] DoorMover doorMover;
    [SerializeField] KeyCardColor keyColor;

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
                        doorMover.StartOpenCloseDoor();
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