using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    public bool isHidden;
    public bool key;
    public bool phoneBook;
    public GameObject stealthIndicator;
    public GameObject spawnLocation;
    public GameObject startingCam;
    private bool m_FacingRight = true;
    public Animator anim;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        spriteFlip();
        if (isHidden)
            stealthIndicator.SetActive(true);
        if (!isHidden)
            stealthIndicator.SetActive(false);
    }

    public void reset()
    {
        gameObject.transform.position = spawnLocation.transform.position;
        GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
        startingCam.SetActive(true);
        startingCam.tag = "MainCamera";
        startingCam.GetComponent<Ending>().activateBegin = true;
    }
    void spriteFlip()
    {
        if (Input.GetAxis("Horizontal") == 0.0)
        {
            anim.SetBool("isWalking", false);
        }
        else
        {
            anim.SetBool("isWalking", true);
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
    void Movement()
    {
        float posX = Input.GetAxis("Horizontal");
        float posZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(posX, 0, posZ);
        if (move.magnitude > 1)
            move = move.normalized;

        move = move * speed * Time.deltaTime;

        transform.position = transform.position + move;
    }
}
