using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer_bow : MonoBehaviour
{
    private float dis;
    public float launchForce;
       
    
       private Rigidbody2D rb;
       private Transform player;
       public Transform shotPoint;
       public GameObject arrow;
       
       
       private void Start()
       {
          player = GameObject.FindGameObjectWithTag("Player").transform;
          rb = GetComponent<Rigidbody2D>();
       }
    
       private void Update()
       {
          
          Vector2 direction = player.position - transform.position;
          dis = Vector2.Distance(transform.position, player.position);
          float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
          transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

       }
    
       

       
   
    
      public void Shoot()
       {
          GameObject newArrow =Instantiate(arrow, shotPoint.position, Quaternion.identity);
          newArrow.GetComponent<Rigidbody2D>().AddForce(shotPoint.up * launchForce*Time.deltaTime,ForceMode2D.Impulse); 

          Destroy(newArrow, 3f);
       }
}
