using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lifeTime = 5f;
    public int damage = 1;
    public int piercingAmount = 1;
    public int piercingLife;
    public float explosionRadius = 0f;

    // Start is called before the first frame update
    void Start()
    {
        piercingLife = piercingAmount;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveSpeed * Time.deltaTime * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable) && !other.TryGetComponent(out PlayerHealthManager player))
        {
            damageable.Damage(damage);
            piercingLife--;
            if (piercingLife <= 0) Destroy(gameObject);
        }
    }
}
