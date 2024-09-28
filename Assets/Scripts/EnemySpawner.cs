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

    [SerializeField] GameObject enemy;
    [Space]
    public float x;
    public float yMin;
    public float yMax;
    [Space]
    public float spawnInterval;

    public bool hasSpawnedAll;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        Instantiate(enemy, new Vector2(x, ranY), Quaternion.identity);
        LevelManager.Instance.AddEnemy();
    }
}
