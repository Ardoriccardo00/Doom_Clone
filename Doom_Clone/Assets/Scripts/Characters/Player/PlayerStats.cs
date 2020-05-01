using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    Health playerHealth;
    /*[SerializeField]*/ Animator redScreenAnimator;
    [SerializeField] Image redScreen;

    public static PlayerStats Instance { get; private set; }

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
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        redScreenAnimator = redScreen.gameObject.GetComponent<Animator>();
    }    

    void Update()
    {
        healthText.text = Convert.ToString(playerHealth.ReturnHealth());
    }

    public void FadePainRedScreen()
    {
        redScreenAnimator.SetTrigger("fade");
    }
} 