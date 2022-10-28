using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    public float attackRange = 1f;
    private float waitTime;
    private float distance;


    private int randomSpot;

    private bool isPlayerAround = false;
    public bool canAttack= true;

    public Transform[] moveSpots;
    public Transform attackPos;
    private Transform player;
    private Vector2 look = Vector2.right;

    public AudioSource source;
    public AudioClip clip;
   
    
    private Animator animator;
    private Rigidbody2D rb;
    public LayerMask layer ;
    



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0,moveSpots.Length);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(rb.position, player.position);
        if (distance >7f)
        {
            isPlayerAround = false;
        }
        else if (distance<7f&&distance>1.5f)
        {
            animator.SetBool("isMoving",true);
            isPlayerAround = true;
        }
        else if (distance<2f)
        {
          
            isPlayerAround = false;
            animator.SetTrigger("attack");
        }
        
        if (transform.position.x>player.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (transform.position.x<player.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    
    private void FixedUpdate()
    {
    
        if (!isPlayerAround)
        {
            Patrol();
        }
        else if (isPlayerAround)
        {
            Follow();
        }
       

    }
    

    void Patrol()
    {
        if (isPlayerAround)
            return;
            
        
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position,moveSpots[randomSpot].position)<0.2f)
        {
            if (waitTime<=0)
            {
                randomSpot = Random.Range(0,moveSpots.Length);
                waitTime = startWaitTime;
                animator.SetBool("isMoving",true);
                if (transform.position.x>moveSpots[randomSpot].position.x)
                { 
                    look = Vector2.left;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (transform.position.x<moveSpots[randomSpot].position.x)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    look = Vector2.right;
                }
            }
            else
            {
                animator.SetBool("isMoving", false);
                waitTime -= Time.deltaTime;
            }
        }
    }

    void Follow()
    {
        Vector2 target = new Vector2(player.position.x-transform.localScale.x,transform.position.y);
        Vector2 newPos =  Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
       
    }

    public void Attack()
    {
        if (canAttack)
        {
            Collider2D colInfo = Physics2D.OverlapCircle(attackPos.position, attackRange, layer);
            if (colInfo!=null)
            {
                source.clip = clip;
                source.Play();
                colInfo.GetComponent<PlayerHealth>().TakeDamage(5);

            }
        }
        
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
