using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class Cyclop_Run : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    private Cyclop cyclop;
    
    public float speed;
    public float attackRange;

    public AudioClip roar, growl;
    private AudioSource source;
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        cyclop = animator.GetComponent<Cyclop>();
        source = animator.GetComponent<AudioSource>();
        source.clip = growl;
        source.Play();

    }

  
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cyclop.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos= Vector2.MoveTowards(rb.position,target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(rb.position,player.position)<= attackRange)
        {
            speed = 0f;
            animator.SetTrigger("Attack");
        }
        else
        {
            speed = 3f;
        }


    }

  
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        source.clip = roar;
        source.Play();
    }
    
    
      

}

   
    
