using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{
    #region Singleton
    public static PlayerHealthManager Instance { get; private set; }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Health"))
        {
            PlayerPrefs.SetInt("Health", 50);
        }
        else
        {
            playerHealth = PlayerPrefs.GetInt("Health");
        }

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    #endregion

    public int playerHealth = 50;

    [Header("Sound")]
    public AudioClip damageSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        playerHealth -= damage;

        PlayerPrefs.SetInt("Health", playerHealth);
        SFXManager.PlaySound(damageSound, 0.9f, 1.1f, 0.9f, 1.1f);

        if (playerHealth <= 0) Kill();
    }

    public void Kill()
    {
        PlayerPrefs.DeleteKey("Level");
        PlayerPrefs.DeleteKey("Health");
        Debug.Log("Game Over");
    }
}
