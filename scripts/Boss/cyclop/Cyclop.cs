using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class Cyclop : MonoBehaviour
{
    public static Cyclop instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform player;
    public Transform attackPos;

    public float attackRange;
    private float health = 400f;


    private LayerMask attackMask;
    public Image healthBar;

    public bool isFlipped = false;
    public bool isDead = false;

    private void Start()
    {
        attackMask = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        healthBar.fillAmount = health / 400;
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

    public void Attack()
    {
        Collider2D colInfo = Physics2D.OverlapCircle(attackPos.position, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(20);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }

    public void TakeDamage(int damage)
    {
        if (health>0f)
        {
            health -= damage;
        }

     
    }

    private void Death()
    { isDead = true;
       Destroy(GameObject.FindGameObjectWithTag("CyclopHealthBar")); 
       Destroy(gameObject);
    }
    
}
