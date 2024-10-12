using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager Instance { get; private set; }
    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        if (!PlayerPrefs.HasKey("Enemies"))
        {
            PlayerPrefs.SetInt("Enemies", Mathf.CeilToInt(1 * 10 * 0.75f));
        }

        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    #endregion

    private void Start()
    {
        enemyAmount = PlayerPrefs.GetInt("Enemies");
        ToLevel(PlayerPrefs.GetInt("Level"));
    }

    public int currentLevel;

    public void NextLevel()
    {
        canLevelUp = true;
        Time.timeScale = 1;
        currentLevel++;
        enemyAmount = Mathf.CeilToInt(currentLevel * 10 * 0.75f);
        EnemySpawner.Instance.SpawnEnemies();
    }

    public void ToLevel(int level)
    {
        canLevelUp = true;
        Time.timeScale = 1;
        currentLevel = level;
        enemyAmount = Mathf.CeilToInt(currentLevel * 10 * 0.75f);
        EnemySpawner.Instance.SpawnEnemies();
    }

    public int enemiesInLevel;
    public int enemyAmount;

    public void AddEnemy()
    {
        enemiesInLevel++;
    }

    public bool canLevelUp = true;

    public void RemoveEnemy()
    {
        enemiesInLevel--;
        
        if (enemiesInLevel <= 0 && EnemySpawner.Instance.hasSpawnedAll && canLevelUp == true)
        {
            PlayerPrefs.SetInt("Level", currentLevel);
            canLevelUp = false;
            OpenEndLevel();
        }
    }

    [SerializeField] GameObject endLevel;

    public void OpenEndLevel()
    {
        endLevel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Level", currentLevel);
    }
}
