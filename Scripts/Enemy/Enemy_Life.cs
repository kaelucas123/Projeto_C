using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Life : MonoBehaviour
{
    [SerializeField] private int hp;

    void Update()
    {
        if (hp < 1)
        {
            DestroyEnemy();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Bullet")) {

        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void takeDamage(int Damage)
    {
        hp -= Damage;
    }
}
