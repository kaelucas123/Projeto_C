using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int curentHealth;
    public bool canTakeDamage = true;

    public Health health;

    private IEnumerator turnCanTakeDamage()
    {
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }

    void Start()
    {
        curentHealth = maxHealth;
        health.SetMaxHealth(maxHealth);
        health.SetHealth(maxHealth);
    }

    void Update()
    {
        if (!canTakeDamage)
        {
            StartCoroutine(turnCanTakeDamage());
            Debug.Log(curentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        health.SetHealth(curentHealth);
    }
}
