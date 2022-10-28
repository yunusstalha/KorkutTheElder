using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack = 0f;
    public float startTimeBtwAttack;
    public float attackRange;
    public int damage = 10;

    public Transform attackPos,effectPos;
    private LayerMask whoIsEnemy;
    private Animator anim;
    private AudioSource source;
    public AudioClip swordClash;
    public GameObject camAnim,hitEffect;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        whoIsEnemy = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
        if (timeBtwAttack<=0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
               
                anim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whoIsEnemy);
                
                   
                for (int i = 0; i <enemiesToDamage.Length; i++)
                {
                    if (enemiesToDamage[i].CompareTag("Enemy"))
                    {
                        Instantiate(hitEffect, effectPos.position, Quaternion.Euler(0f,0f,0f));
                        source.clip = swordClash;
                        source.Play();
                        camAnim.GetComponent<Animator>().SetTrigger("shake");
                        enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                    }
                    else if (enemiesToDamage[i].CompareTag("Cyclop"))
                    {
                        Instantiate(hitEffect, effectPos.position, Quaternion.Euler(0f,0f,0f));
                        source.clip = swordClash;
                        source.Play();
                        camAnim.GetComponent<Animator>().SetTrigger("shake");
                        enemiesToDamage[i].GetComponent<Cyclop>().TakeDamage(damage);
                    }
                    else if (enemiesToDamage[i].CompareTag("CyclopBody"))
                    {
                        Instantiate(hitEffect, effectPos.position, Quaternion.Euler(0f,0f,0f));
                        source.clip = swordClash;
                        source.Play();
                        camAnim.GetComponent<Animator>().SetTrigger("shake");
                    }
                    else if (enemiesToDamage[i].CompareTag("cob"))
                    {
                        Instantiate(hitEffect, effectPos.position, Quaternion.Euler(0f,0f,0f));
                        source.clip = swordClash;
                        source.Play();
                        camAnim.GetComponent<Animator>().SetTrigger("shake");
                        enemiesToDamage[i].GetComponent<cob>().TakeDamage(damage);
                    }
                    else if (enemiesToDamage[i].CompareTag("azitmis"))
                    {
                        Instantiate(hitEffect, effectPos.position, Quaternion.Euler(0f,0f,0f));
                        source.clip = swordClash;
                        source.Play();
                        camAnim.GetComponent<Animator>().SetTrigger("shake");
                        enemiesToDamage[i].GetComponent<Azitmis>().TakeDamage(damage);
                    }

                       
                }
                timeBtwAttack = startTimeBtwAttack;
                
                
            }
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }
}
