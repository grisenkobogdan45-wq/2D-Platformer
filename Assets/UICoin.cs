using UnityEngine;
using TMPro;
using System;

public class UICoin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI moneyText;
    public playerCoin playerWealth;
    void Start()
    {
        playerWealth.MoneyChanged += MoneyChanged;
    }

    private void OnMoneyInit(float newcoin)
    {
        moneyText.text = newcoin.ToString();
    }

    public void MoneyChanged(float newcoin, float ammountChanged)
    {
        //Debug.Log("On Health Changed Event");
        moneyText.text = newcoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
