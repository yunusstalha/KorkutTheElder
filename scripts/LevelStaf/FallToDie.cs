using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FallToDie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().Death();
        }
        
    }
}
