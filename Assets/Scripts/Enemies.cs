using System.Collections;
using Unity.Collections;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    float health, harm;
    int points;
    public GameObject player, pemPoison;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform Enemy;
    [SerializeField] private SphereCollider EnemyHitbox;


    private Vector3 GrowthRate, DamageShrink;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Grow", 0.5f, 2f);
        InvokeRepeating("DealDamage", 3f, 1f);
        
    }

    private void Awake()
    {
        health = 10f;
        harm = 2f;
        rb = GetComponent<Rigidbody>();
        Enemy = GetComponent<Transform>();
        EnemyHitbox = GetComponent<SphereCollider>();

        GrowthRate = new Vector3(0.5f, 0.5f, 0.5f);
        DamageShrink = new Vector3(-0.1f, -0.1f, -0.1f);
        player = GameObject.FindWithTag("player");
        points = 500;
    }

    void Grow()
    {
        Enemy.localScale += GrowthRate;
        health += 5;
        points -= 50;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Enemy.localScale += DamageShrink;
    }

    private void DealDamage()
    {
        if (player != null)
        {
            player.transform.GetComponent<Player>().TakeDamage(harm);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.localScale.x >= 3.5 || player == null)
        {
            CancelInvoke("Grow");
            
        }
        if (health <= 0 || Enemy.localScale.x <= 0.4) {
            if (player != null)
            {
                player.transform.GetComponent<Player>().AddScore(points);
            }
            if (pemPoison != null)
            {
                Vector3 Spawn = new Vector3(Enemy.position.x, Enemy.position.y, Enemy.position.z);
                GameObject poison = Instantiate(pemPoison, Spawn, Quaternion.identity);
                poison.SetActive(false);
                //Instantiate(pemPoison, Spawn, Quaternion.identity);
            }
            CancelInvoke("DealDamage");
            Destroy(this.gameObject);
        }
    }
}
