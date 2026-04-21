using System;
using System.Collections;
using UnityEngine;


public class playerCoin : MonoBehaviour
{
    private float money;
    public delegate void MoneyChangedHandler(float newcoin, float ammountchanged);
    public event MoneyChangedHandler MoneyChanged;
    public delegate void Moneyinitalized(float newhave);
    public event Moneyinitalized OnMoneyInitialized;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = 0;
    }



    // Update is called once per frame
    void Update()
    {

    }
    public void Addmoney(float coin)
    {
        money += coin;
        MoneyChanged?.Invoke(money, coin);
    }

}
