using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cyclop_Idle : StateMachineBehaviour
{
    public static Cyclop_Idle instance;

    private void Awake()
    {
        instance = this;
    }

    private Transform player;
    private float dis;
    public bool isPlayerSeen = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dis = Vector2.Distance(animator.GetComponent<Rigidbody2D>().position, player.position);
        if (dis<7f)
        {
            isPlayerSeen = true;
            animator.SetBool("isEnemySeen",true);
            
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }


}
