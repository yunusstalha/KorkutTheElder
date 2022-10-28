using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class azitmi_bomb : MonoBehaviour
{
    [SerializeField] private GameObject bombEffect;
    private GameObject cam;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("vcam");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cam.GetComponent<Animator>().SetTrigger("shake");
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
            Instantiate(bombEffect, other.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (!other.gameObject.CompareTag("azitmis"))
        {
            cam.GetComponent<Animator>().SetTrigger("shake");
            Destroy(gameObject);
        }
        
            
        
    }
}
