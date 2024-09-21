using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [Space]
    public float x;
    public float yMin;
    public float yMax;
    [Space]
    public float spawnInterval;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            float ranY = Random.Range(yMin, yMax);
            Instantiate(enemy, new Vector2(x, ranY), Quaternion.identity);

            timer = spawnInterval;
        }
        else timer -= Time.deltaTime;
    }
}
