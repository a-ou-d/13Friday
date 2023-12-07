using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]private GameObject player;
    public GameObject Bullet;
    public int damage = 1;
    public float speed = 10;
    public float attackDelay = 0.2f;
    private float timeSinceLastAttack;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void FixedUpdate()
    {

        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {

        if (timeSinceLastAttack <= attackDelay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if (timeSinceLastAttack > attackDelay)
        {
            timeSinceLastAttack = 0f;
            ShootBullet();
            
        }
    }

    public void ShootBullet()
    {

        GameObject bulletObject = Instantiate(Bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();

        Vector2 dri = (player.transform.position - transform.position).normalized;
        rb.AddForce(dri * speed, ForceMode2D.Impulse);

    }

}
