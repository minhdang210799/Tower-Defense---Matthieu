using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    void Awake()
    {
        int damage = Mathf.CeilToInt(LevelManager.Instance.currentLevel * 1.25f);
        if (!PlayerPrefs.HasKey("EnemyDamage"))
        {
            PlayerPrefs.SetInt("EnemyDamage", damage);
            this.damage = damage;
        }
        else
        {
            this.damage = PlayerPrefs.GetInt("EnemyDamage");
        }
    }

    public float moveSpeed = 1f;
    public float health = 3f;
    [Space]
    public float attackRange = 0.5f;
    public int damage = 2;
    public float attackDelay;
    float timer;
    [Space]
    public int coinsReward = 2;

    [Header("FX")]
    public AudioClip damageSound;
    public ParticleSystem damageFX;

    // Start is called before the first frame update
    void Start()
    {
        timer = attackDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanDamagePlayer())
        {
            if (timer <= 0)
            {
                PlayerHealthManager.Instance.Damage(damage);
                timer = attackDelay;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        else
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }
    }

    bool CanDamagePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, attackRange);

        if (hit.collider == null) return false;
        if (!hit.collider.TryGetComponent(out PlayerHealthManager player)) return false;

        return true;
    }

    public void Damage(int damage)
    {
        health -= damage;

        SFXManager.PlaySound(damageSound, 0.9f, 1.1f, 0.9f, 1.1f);

        if (health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        CoinManager.Instance.AddCoins(coinsReward);
        LevelManager.Instance.RemoveEnemy();
        VFXManager.SpawnVFX(damageFX, transform.position);

        PlayerPrefs.SetInt("EnemyDamage", damage);

        Destroy(gameObject);
    }
}
