using System;
using UnityEngine;

public class Elevator : MonoBehaviour, IEInteractable
{
    [SerializeField] Vector3 startingPos;
    [SerializeField] Vector3 endPos;
    Vector3 newPos;
    bool canMove = false;

    float maxTimer = 5;
    float timer;

    void Start()
    {
        timer = maxTimer;
        newPos = startingPos;
    }    

    void Update()
    {
        if(canMove)
        {
            transform.Translate(newPos * Time.deltaTime);
            if(transform.position.y >= newPos.y)
            {
                canMove = false;
            }
        }
    }

    public void Interactable()
    {
        GoToEnd();
    }

    void GoToEnd()
    {
        print("go to end");
        newPos = endPos;
        canMove = true;
    }

    void GoToStart()
    {
        newPos = startingPos;
        canMove = true;
    }
} 