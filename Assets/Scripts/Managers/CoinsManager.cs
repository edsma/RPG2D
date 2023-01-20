using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : Singleton<CoinsManager>
{
    [SerializeField] private int coinsTest;
    public int totalsCoins{ get; private set; }
    private string keyCoins = "MyGame_Coins";

    public void AddCoins(int quantity){
        totalsCoins += quantity;
        PlayerPrefs.SetInt(keyCoins,totalsCoins);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        PlayerPrefs.DeleteKey(keyCoins);
        UpdateCoins();
    }

    private void UpdateCoins()
    {
        totalsCoins = PlayerPrefs.GetInt(keyCoins);
    }

    public void RemoveCoins(int quantity) {
        if (quantity > totalsCoins)
        {
            return;
        }
        totalsCoins -= quantity;
        PlayerPrefs.SetInt(keyCoins, totalsCoins);
        PlayerPrefs.Save();
    }
}
