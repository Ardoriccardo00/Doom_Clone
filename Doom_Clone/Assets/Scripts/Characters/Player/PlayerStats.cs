using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Image redScreen;

    Health playerHealth;
    Animator redScreenAnimator;

    #region Singleton
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
    #endregion

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