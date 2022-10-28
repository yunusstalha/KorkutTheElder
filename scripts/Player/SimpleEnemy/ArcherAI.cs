using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ArcherAI : MonoBehaviour
{
   private float dis;
   public float speed = 7;

   

   private Rigidbody2D rb;
   private Animator anim;
   private Transform player;
   private bool isPlayerAround = false;
   private bool isPlayerToClose = false;
   
   
   
   private void Start()
   {
      anim = GetComponent<Animator>();
      player = GameObject.FindGameObjectWithTag("Player").transform;
      rb = GetComponent<Rigidbody2D>();
   }

   private void Update()
   {
   
      dis = Vector2.Distance(transform.position, player.position);
      if (transform.position.x>player.position.x)
      {
         transform.localScale = new Vector3(-1, 1, 1);
      }
      else if (transform.position.x<player.position.x)
      {
         transform.localScale = new Vector3(1, 1, 1);
      }

      if (dis>15f)
      {
         isPlayerAround = false;
      }
      else if (dis<15f&&dis>10f)
      {
         anim.SetBool("isMoving",true);
         isPlayerAround = true;
      }
      else if (dis < 10f && dis > 5f)
      {
         anim.SetTrigger("Attack");
         isPlayerAround = false;
      }
      else if (dis<0.2f)
      {
         anim.SetBool("isMoving",true);
         isPlayerAround = false;
         isPlayerToClose = true;
      }
      
  
      
   }

   
   private void FixedUpdate()
   {
      if (!isPlayerAround&&!isPlayerToClose)
      {
         return;
      }
      else if (isPlayerAround)
      {
         Follow();
      }
      else if (isPlayerToClose)
      {
         Escape();
      }


   }
   
   void Follow()
   {
      
      Vector2 target = new Vector2(player.position.x-transform.localScale.x,rb.position.y);
      Vector2 newPos =  Vector2.MoveTowards(rb.position, target, speed * Time.deltaTime);
      rb.MovePosition(newPos);
      
   }

   void Escape()
   {
      Vector2 target = new Vector2(player.position.x-transform.localScale.x,rb.position.y);
      Vector2 newPos =  Vector2.MoveTowards(rb.position, target, -speed * Time.deltaTime);
      rb.MovePosition(newPos);
   }

   public void Shoot()
   {
      GetComponentInChildren<Archer_bow>().Shoot();
   }

  
}
