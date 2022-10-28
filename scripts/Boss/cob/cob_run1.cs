using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cob_run1 : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rb;

    private cob cob;
    
    public float speed;
    public float attackRange;
    
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        cob = animator.GetComponent<cob>();


    }

  
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float z;
        cob.LookAtPlayer();
        if (rb.position.x >player.position.x)
        {
            z = -1;
            
        }
        else
        {
           z = 1;
        }
        Vector2 target = new Vector2(player.position.x -1.5f*z, rb.position.y);
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
     
    }
}
