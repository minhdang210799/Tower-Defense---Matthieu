using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{
    #region Singleton
    public static PlayerHealthManager Instance { get; private set; }
    private void Awake()
    {
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

        if (playerHealth <= 0) Kill();
    }

    public void Kill()
    {
        Debug.Log("Game Over");
    }
}
