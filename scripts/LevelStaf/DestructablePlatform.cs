using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructablePlatform : MonoBehaviour
{
    public GameObject effect;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(effect, transform.position, Quaternion.Euler(90,0,0));
        Invoke("Destruction",1f);
        
    }

   void  Destruction()
    {
        Instantiate(effect, transform.position, Quaternion.Euler(90,0,0));
        Instantiate(effect, transform.position, Quaternion.Euler(90,0,0));
        Instantiate(effect, transform.position, Quaternion.Euler(90,0,0));
        Destroy(gameObject);
    }
}
