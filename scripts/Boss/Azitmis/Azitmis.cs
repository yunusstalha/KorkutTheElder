using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azitmis : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float MaxHealth;
    private float health;
    public bool isDead = false;
    [SerializeField] private bool isFlipped;
    [SerializeField] private GameObject effect;
    
   [SerializeField] AudioSource source;
   [SerializeField] private AudioClip clip;
    
   
   
    
    void Start()
    {
        health = MaxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
    void Update()
    {
        if (health<= 0)
        {
            Death();
        }
    }
    
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        
        if (transform.position.x>player.position.x &&isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = false;
        }
        else if (transform.position.x< player.position.x &&!isFlipped)
                
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = true;
        }
        
        
        
     
        
    }
    public void Shoot()
    {
        source.clip = clip;
        source.Play();
        GetComponentInChildren<Azitmis_Fire>().Shoot();
    }

    public void TakeDamage(int damage)
    {
        if (health>0)
        {
            health -= damage;
        }
    }

    private void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.clip = clip;
            source.Play();
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(5);
            Instantiate(effect, other.transform.position, Quaternion.identity);
            Instantiate(effect, other.transform.position, Quaternion.identity);
        }
    }
}
