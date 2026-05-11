using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    
    public int coins;
    public TextMeshProUGUI coinsText;

    private void Start()
    {
        Reset();
        UpdateCoinsUI();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UpdateCoinsUI();
    }

    private void UpdateCoinsUI()
    {
        coinsText.text = coins.ToString();
    }
}
