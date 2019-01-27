using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiAnimatorController : MonoBehaviour
{

    //  public CharacterController2D controller;
  //  public float speed = 5;
    // public float horizontalMove = 1f;

    //private float JumpForce = 400f;
    private bool m_FacingRight = true;
    public Animator anim;
    private Rigidbody rb;
    // bool jump = false;

    // bool crouch = false;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        
        spriteFlip();

    }
    void spriteFlip()
    {
        if (gameObject.transform.hasChanged)
        {
            anim.SetBool("fatherWalk", true);
        }
        else
        {
            anim.SetBool("fatherWalk", false);
        }

        if (Input.GetAxis("Horizontal") > 0 && !m_FacingRight)
        {
            //   anim.SetBool("isWalking", true);
            Flip();
        }
        else if (Input.GetAxis("Horizontal") < 0 && m_FacingRight)
        {
            // anim.SetBool("isWalking", true);
            Flip();
        }
    }
    private void Flip()

    {

        // Switch the way the player is labelled as facing.

        m_FacingRight = !m_FacingRight;



        // Multiply the player's x local scale by -1.

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;

    }
    

    void FixedUpdate()

    {

        // controller.Move(move, crouch, jump);//time.fixed keeps the movement constant

        //jump = false;

    }

}
