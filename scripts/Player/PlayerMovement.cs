using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Animator animator;
    public GameObject camAnim;
    public GameObject dust;
    private Rigidbody2D rb;

    private AudioSource source;
    public AudioClip dash;

    [SerializeField] private float runSpeed = 40f;
    private float horizontalMove = 0f;
    private float dashTime= 0f;
    private float startDashTime = 1f;
    private float lastClickedTime;

    private Vector2 dashDir;
    

    private bool jump = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping",true);
        }

        if (transform.localScale.x == -1)
        {
            dashDir = Vector2.left;
        }
        else if (transform.localScale.x == 1)
        {
            dashDir = Vector2.right;
        }
        Dash();
    }
    

    private void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime,false,jump);
        jump = false;
       
    }

   public void OnLanding()
    {
        camAnim.GetComponent<Animator>().SetTrigger("shake");
        animator.SetBool("IsJumping",false);
        Instantiate(dust, new Vector3(transform.position.x, transform.position.y - 1.7f, transform.position.z),Quaternion.identity);
    }

   void Dash()
   {
       if (dashTime<= 0)
       {
           if (Input.GetKeyDown(KeyCode.X))
           {
                   source.clip = dash;
                   source.Play();
                   animator.SetTrigger("Dash");
                   rb.AddForce(dashDir * 20000 * Time.deltaTime, ForceMode2D.Impulse);
                   dashTime = startDashTime;
           
           }
   

          
       }
       else
       {
           dashTime -= Time.deltaTime;
       }
       
   }

}
