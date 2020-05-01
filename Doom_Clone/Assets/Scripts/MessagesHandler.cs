using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class MessagesHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;
    Animator animator;
    bool isBusy = false;

    public static MessagesHandler Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        animator = messageText.GetComponent<Animator>();
    }    

    public bool ReturnIsBusy()
    {
        return isBusy;
    }

    public void WriteMessage(string message)
    {
        if(!isBusy)
            StartCoroutine(FadeMessage(message));
        else
            messageText.text = message;
    }

   IEnumerator FadeMessage(string _message)
    {
        isBusy = true;
        animator.SetTrigger("FadeIn");
        messageText.text = _message;
        yield return new WaitForSeconds(2);
        animator.SetTrigger("FadeOut");
        isBusy = false;
    }
} 