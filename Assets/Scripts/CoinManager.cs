using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    #region Singleton
    public static CoinManager Instance { get; private set; }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", coins);
        }
        else
        {
            coins = PlayerPrefs.GetInt("Coins");
        }

        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

    }
    #endregion

    public int coins;

    public void AddCoins(int coins)
    {
        this.coins += coins;
        PlayerPrefs.SetInt("Coins", this.coins);
    }
}
