using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_Health : MonoBehaviour
{
    public float health;
    public GameObject blood;

    private void Update()
    {
        if (health<= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (health>0f)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            health -= damage;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
