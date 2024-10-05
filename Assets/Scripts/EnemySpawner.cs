using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Singleton
    public static EnemySpawner Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;

    }
    #endregion

    [SerializeField] Enemy enemy;
    [Space]
    public float x;
    public float yMin;
    public float yMax;
    [Space]
    public float spawnInterval;

    public bool hasSpawnedAll;
    [Space]
    public int coinsReward = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LevelManager level = LevelManager.Instance;
        int cl = level.currentLevel;
        spawnInterval = cl - cl * 0.1f - Mathf.Floor(cl - cl * 0.1f);
    }

    public void SpawnEnemies()
    {
        StartCoroutine(SpawnTheEnemies());
    }

   IEnumerator SpawnTheEnemies()
    {
        LevelManager level = LevelManager.Instance;
        for (int i = 0; i < level.enemyAmount; i++)
        {
            Spawn();
            yield return new WaitForSeconds(spawnInterval);
        }

        hasSpawnedAll = true;
    }

    void Spawn()
    {
        float ranY = Random.Range(yMin, yMax);
        Enemy enemy = Instantiate(this.enemy, new Vector2(x, ranY), Quaternion.identity);
        enemy.coinsReward = coinsReward;
        LevelManager.Instance.AddEnemy();
    }
}
