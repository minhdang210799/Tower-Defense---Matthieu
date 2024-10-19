using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    #region Singleton
    public static UpgradeManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    #endregion

    [SerializeField] PlayerHealthManager healthManager;
    [SerializeField] Shoot shootScript;
    [SerializeField] EnemySpawner enemySpawner;

    [Header("Sound")]
    public AudioClip upgradeSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade(ShopItem item)
    {
        if (item == null) return;
        if (CoinManager.Instance.coins < item.cost) return;

        if (item.buffType == ShopItemBuffType.Health)
        {
            HandleHealthUpgrades(item);
        }
        else if (item.buffType == ShopItemBuffType.Money)
        {
            HandleEnemyUpgrades(item);
        }
        else
        {
            HandleShootingUpgrades(item);
        }

        CoinManager.Instance.AddCoins(-item.cost);
        SFXManager.PlaySound(upgradeSound);
    }

    void HandleHealthUpgrades(ShopItem item)
    {
        healthManager.Heal((int)item.buffAmount);
    }

    void HandleShootingUpgrades(ShopItem item)
    {
        Shoot s = shootScript;
        switch (item.buffType)
        {
            case ShopItemBuffType.Firerate:
                s.shootDelay += item.buffAmount;
                PlayerPrefs.SetFloat("Fierate", s.shootDelay); break;
            case ShopItemBuffType.Piercing:
                s.piercingAmount += (int)item.buffAmount;
                PlayerPrefs.SetInt("Piercing", s.piercingAmount); break;
            case ShopItemBuffType.Arrows:
                s.arrowAmount += (int)item.buffAmount;
                PlayerPrefs.SetInt("Arrow", s.arrowAmount); break;
        }
    }

    void HandleEnemyUpgrades(ShopItem item)
    {
        enemySpawner.coinsReward += (int)item.buffAmount;
        PlayerPrefs.SetInt("Reward", enemySpawner.coinsReward);
    }
}
