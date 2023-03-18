using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceButton : MonoBehaviour
{
    [SerializeField] private int watchPrize = 1;
    [Header("Refs")]
    [SerializeField] private TMP_Text priceLabel;
    [SerializeField] private Button priceButton;

    private void Start()
    {
        //setup label
        priceLabel.text += watchPrize;
        //setup money
        MoneyManager.instance.onMoneyChanged += OnPriceChange;
        CheckPrice();
    }

    //========= handle price change ==========
    private void OnPriceChange(int money)
    {
        CheckPrice();
    }
    private void CheckPrice()
    {
        if (MoneyManager.instance.MoneyCheck(watchPrize)) { Enable(); }
        else { Disable(); }
    }
    private void OnEnable()
    {
        CheckPrice();
    }

    //========= handle state changes ===========
    private void Enable()
    {
        if (!priceButton.interactable) {
            priceLabel.color = Color.white;
            priceButton.interactable = true;
        }
    }
    private void Disable()
    {
        if (priceButton.interactable) {
            priceLabel.color = Color.red;
            priceButton.interactable = false;
        }
    }
}
