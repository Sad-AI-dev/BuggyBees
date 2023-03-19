using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyLabel : MonoBehaviour
{
    private TMP_Text label;

    private void Start()
    {
        label = GetComponent<TMP_Text>();
        MoneyManager.instance.onMoneyChanged += UpdateLabel;
        UpdateLabel(MoneyManager.instance.GetCurrentMoney());
    }

    private void UpdateLabel(int money)
    {
        label.text = money.ToString();
    }

    private void OnDestroy()
    {
        MoneyManager.instance.onMoneyChanged -= UpdateLabel;
    }
}
