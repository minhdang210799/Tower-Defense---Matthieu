using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetUIPlayerValues : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI coinsCounter;
    [SerializeField] TextMeshProUGUI levelCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = PlayerHealthManager.Instance.playerHealth;
        coinsCounter.text = CoinManager.Instance.coins.ToString();
        levelCounter.text = LevelManager.Instance.currentLevel.ToString();
    }
}
