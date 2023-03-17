using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public static MoneyManager instance;

    [SerializeField] private int money = 0;
    public Action<int> onMoneyChanged;

    public void GainMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }

    public bool MoneyCheck(int amount)
    {
        return money >= amount;
    }
    public void PayMoney(int moneyToPay)
    {
        money -= moneyToPay;
    }
}
