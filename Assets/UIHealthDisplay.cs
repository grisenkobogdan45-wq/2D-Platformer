using UnityEngine;
using TMPro;
using System;

public class UIHealthDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI healthText;
    public help playerHealth;
    void Start()
    {
        playerHealth.OnHealthChanged += OnHealthChanged;
        playerHealth.OnHealthInitialized += OnHealthInit;
    }

    private void OnHealthInit(float newhave)
    {
        healthText.text = newhave.ToString();
    }

    public void OnHealthChanged(float newHealth, float ammountChanged)
    {
        //Debug.Log("On Health Changed Event");
        healthText.text = newHealth.ToString();
    }
      
    // Update is called once per frame
    void Update()
    {
        
    }
}
