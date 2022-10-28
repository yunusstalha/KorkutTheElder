using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   public static PlayerHealth instance;

   private void Awake()
   {
      instance = this;
   }

   public float health = 100f;
   public Image healthBar;
   public bool isDead = false;

   private void Update()
   {
      healthBar.fillAmount = health / 100;
      if (health<= 0f)
      {
         Death();
      }
   }

   public void TakeDamage(float damage)
   {
      
      if (health > 0)
      {
         health -= damage;
         
      }
   }

   public void Death()
   {
      isDead = true;
      Destroy(gameObject);
   }


   void normalTime()
   {
      Time.timeScale = 1f;
   }
}
