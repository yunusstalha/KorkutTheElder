using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class azitmis_move : StateMachineBehaviour
{
    private float waitTime;
   [SerializeField]private float startWaitTime = 10f;
   [SerializeField]private float speed = 6f;

    private int attackType;

    private bool isAttacked = false;
    
    private Transform player;
    private Rigidbody2D rb;
    private Azitmis azitmis;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waitTime = 1f;
        rb = animator.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        azitmis = animator.GetComponent<Azitmis>();


    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float z;
        azitmis.LookAtPlayer();
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
        if (waitTime<= 0f)
        {
            attackType = Random.Range(1, 4);
            Debug.Log(attackType);
            isAttacked = false;
            waitTime = startWaitTime;
            speed = 6f;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        if (attackType ==1&&!isAttacked)
        {
            speed = 0f;
            animator.SetTrigger("bomb");
            waitTime = 10f;
            isAttacked = true;
        }
        else if (attackType==2&& !isAttacked)
        {
            speed = 15f;
            Debug.Log("Spear!");
            animator.SetTrigger("spear");
            waitTime = 12f;
            isAttacked = true;
            attackType = 3;
        }
        else if (attackType==3&& !isAttacked)
        {
            speed = 0f;
            waitTime = 2f;
            isAttacked = true;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
 
    }


}
