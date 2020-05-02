using System;
using System.Collections;
using UnityEngine;

public class DoorMover : MonoBehaviour, IEInteractable
{
    [SerializeField] Animator animator;
    [SerializeField] bool directionLeft = false;

    void Start()
    {
        animator.GetComponent<Animator>();
    }

    public void Interactable()
    {
        StartCoroutine(OpenCloseDoor());
    }

    public void OpenDoor(bool left)
    {
        if(left)
        {
            animator.SetTrigger("openLeft");
        }
        else
        {
            animator.SetTrigger("openRight");
        }
    }

    public void CloseDoor(bool left)
    {
        if(left)
        {
            animator.SetTrigger("closeLeft");
        }
        else
        {
            animator.SetTrigger("closeRight");
        }
    }

    public IEnumerator OpenCloseDoor()
    {
        MessagesHandler.Instance.WriteMessage("Start open");
        OpenDoor(directionLeft);
        yield return new WaitForSeconds(2);
        MessagesHandler.Instance.WriteMessage("Start close");
        CloseDoor(directionLeft);
    }
} 