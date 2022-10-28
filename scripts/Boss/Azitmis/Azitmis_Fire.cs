using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Azitmis_Fire : MonoBehaviour
{

    public float launchForce;
       
    
    private Rigidbody2D rb;
    private Transform player;
    [SerializeField] Transform shotPoint;
    [SerializeField] GameObject arrow;
       
       
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
          
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);

    }
    
       

       
   
    
    public void Shoot()
    {
        GameObject newArrow =Instantiate(arrow, shotPoint.position, Quaternion.identity);
        newArrow.GetComponent<Rigidbody2D>().velocity = shotPoint.up * launchForce;

        Destroy(newArrow, 3f);
    }
}
