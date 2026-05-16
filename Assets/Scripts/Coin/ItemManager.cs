using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    
    public SOInt coins;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        Reset();
        
    }

    private void Reset()
    {
        coins.value = 0;
        UpdateCoinsUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        UpdateCoinsUI();
    }

    private void UpdateCoinsUI()
    {
        //coinsText.text = coins.value.ToString();
    }
}
