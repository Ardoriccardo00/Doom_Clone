using System;
using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour, IEInteractable
{
    [SerializeField] Vector3 startingPos;
    [SerializeField] Transform endPos;
    [SerializeField] Vector3 newPos;
    [SerializeField] float movingSpeeed = 10f;
    bool canMove = false;

    [SerializeField] bool isStartPos = true;

    void Start()
    {
        startingPos = transform.position;
        newPos = startingPos;
    }    

    void Update()
    {
        if(canMove) //move to the new direction
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, movingSpeeed * Time.deltaTime);
            if(transform.position.y == newPos.y)
            {
                canMove = false;
                isStartPos = !isStartPos;
            }
        }
    }

    public void Interactable()
    {
        SetNewDestination();
    }

    private void SetNewDestination()
    {
        if(isStartPos)
        {
            GoToEnd();
        }
        else
        {
            GoToStart();
        }
    }

    void GoToEnd()
    {
        print("go to end");
        newPos = endPos.position;
        canMove = true;
        //  isStartPos = false;
    }

    void GoToStart()
    {
        print("go to start");
        newPos = startingPos;
        canMove = true;
        //isStartPos = true;
    }
} 
/*
void Update()
    {
        print(timer);

        if(canMove) //move to the new direction
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, Time.deltaTime);
            if(transform.position.y == newPos.y)
            {
                canMove = false;
                //isStartPos = false;
                canCountDown = true;
            }
        }

        if(canCountDown)
        {
            timer -= Time.deltaTime / .5f;

            if(timer <= 0)
            {
                canCountDown = false;
                GoToStart();
                timer = maxTimer;
            }
        }
    }

    public void Interactable()
    {
        GoToEnd();
        //StartCoroutine(MoveTo());
    }

    private void SetNewDestination()
    {
        if(isStartPos)
            newPos = endPos.localPosition;
        else
            newPos = startingPos;
    }

    void GoToEnd()
    {
        print("go to end");
        newPos = endPos.position;
        canMove = true;
    }

    void GoToStart()
    {
        print("go to start");
        newPos = startingPos;
        canMove = true;
    }

    IEnumerator MoveTo()
    {
        SetNewDestination();
        canMove = true;
        print("1");
        yield return new WaitForSeconds(10);
        print("2");
        SetNewDestination();
        canMove = true;
        yield return new WaitForSeconds(10);
        print("3");
        canMove = false;
    }*/
