using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cob : MonoBehaviour
{
    public static cob instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform player;
    public Transform attackPos;

    private Rigidbody2D rb;

    public float attackRange;
    private float health = 330f;

    public AudioClip clip;
    private AudioSource source;

    private LayerMask attackMask;
    public Image healthBar;

    public bool isFlipped = false;
    public bool isDead = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        attackMask = LayerMask.GetMask("Player");
    }

    void Update()
    {
        
        healthBar.fillAmount = health / 300;
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
            source.clip = clip;
            source.Play();
            colInfo.GetComponent<PlayerHealth>().TakeDamage(10);
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
    { 
       
        GetComponent<Animator>().SetTrigger("dead");
        Invoke("deattttt",2f);
        Destroy(GameObject.FindGameObjectWithTag("CyclopHealthBar")); 
        
    }

    void deattttt()
    {
        isDead = true;
    }
}
