using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealth : MonoBehaviour
{
 public float health;
 public float startDazeTime;
 private float dazeTime;
 private int index;

 
 public GameObject[] body;

 public GameObject bloodEffect;
 public bool isGuard;


 

 private void Start()
 {
  index =Random.Range(0, body.Length);


 }

 private void Update()
 {

  if (isGuard)
  {
   if (dazeTime<=0)
   {
    GetComponent<EnemyAI>().canAttack = true;
    GetComponent<EnemyAI>().speed = 5;
   }
   else
   {
    GetComponent<EnemyAI>().canAttack = false;
    GetComponent<EnemyAI>().speed = 0;
    dazeTime -= Time.deltaTime;
   }
  }
  else if (!isGuard)
  {
   if (dazeTime<=0)
   {
   
    GetComponent<ArcherAI>().speed = 5;
   }
   else
   {
    GetComponent<ArcherAI>().speed = 0;
    dazeTime -= Time.deltaTime;
   }
  }

  

  if (health<= 0)
  {
   Death();
  }
 }

 public void TakeDamage(int damage)
 {
  if (health>0)
  {
   Instantiate(bloodEffect, transform.position, Quaternion.identity);
   dazeTime = startDazeTime; 
   health -= damage;
   
  }
 }

 void Death()
 {
  Instantiate(bloodEffect, transform.position, Quaternion.identity);
  Instantiate(bloodEffect, transform.position, Quaternion.identity);
  Instantiate(bloodEffect, transform.position, Quaternion.identity);
  Instantiate(body[index], transform.position, Quaternion.identity);
  Destroy(gameObject);
 }
}
