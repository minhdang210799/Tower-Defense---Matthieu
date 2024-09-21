using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] Transform shootPos;

    public float shootDelay;
    float shootTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            TryShoot();
        }

        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    void TryShoot()
    {
        if (shootTimer > 0)
        {
            return;
        }

        SpawnArrow();
        shootTimer = shootDelay;
    }

    void SpawnArrow()
    {
        Instantiate(arrow, shootPos.position, transform.rotation);
    }
}
