using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    public int damage;
    public Player_Health playerHealth;


    private void Start()
    {
        playerHealth = FindAnyObjectByType<Player_Health>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player") && playerHealth.canTakeDamage)
            {
                playerHealth.TakeDamage(damage);
                playerHealth.canTakeDamage = false;
                Debug.Log("Tocou");
            }
        }
    }
  


}
