using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Arrow arrow;
    [SerializeField] Transform shootPos;

    [Header("Shooting Options")]
    public float shootDelay;
    float shootTimer;

    [Header("Arrow Options")]
    public int damage = 1;
    public int piercingAmount = 1;
    public float explosionRadius = 0f;
    public int arrowAmount = 1;
    public float arrowSplitRadius;

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

        arrowSplitRadius = arrowAmount * 10;
    }

    void TryShoot()
    {
        if (shootTimer > 0)
        {
            return;
        }

        ShootArrow();
        shootTimer = shootDelay;
    }

    void ShootArrow()
    {
        if (arrowAmount == 1 || arrowSplitRadius <= 0)
        {
            SpawnArrow();
        }
        else if (arrowAmount > 1)
        {
            Vector3 startRotation = transform.rotation.eulerAngles;
            for (float i = arrowSplitRadius / 2f * -1f; i <= arrowSplitRadius / 2; i += arrowSplitRadius / (arrowAmount - 1))
            {
                transform.rotation = Quaternion.Euler(0, 0, startRotation.z + i);
                SpawnArrow();
            }
            transform.rotation = Quaternion.Euler(startRotation);
        }
    }
    void SpawnArrow()
    {
        Arrow arrow;
        arrow = Instantiate(this.arrow, shootPos.position, transform.rotation);
        arrow.damage = damage;
        arrow.piercingAmount = piercingAmount;
        arrow.explosionRadius = explosionRadius;
    }
}
