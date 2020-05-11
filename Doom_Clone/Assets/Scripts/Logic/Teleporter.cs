using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] Teleporter otherSide;
    public Transform exitSpot;

    private void OnTriggerEnter(Collider other)
    {
        //Teleport(other.gameObject);
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Teleport(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            print("Exit" + other.gameObject);
            //other.GetComponent<PlayerController>().enabled = true;
        }
    }

    void Teleport(GameObject objectToTeleport)
    {
        print("trigger " + objectToTeleport);
        objectToTeleport.GetComponent<PlayerController>().enabled = false;
        objectToTeleport.transform.position = otherSide.exitSpot.transform.position;
        objectToTeleport.GetComponent<PlayerController>().enabled = true;
    }
} 