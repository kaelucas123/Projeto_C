using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 1f;
    [SerializeField] public float delay;
    private Enemy_Life enemyHit;
    
    private IEnumerator DeleteBulletTime()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject, 0);
    }

    
    private void Start()
    {
        StartCoroutine(DeleteBulletTime());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DestroyBullet();         
            enemyHit = collision.gameObject.GetComponent<Enemy_Life>();
            enemyHit.takeDamage(100);
        }
        
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
