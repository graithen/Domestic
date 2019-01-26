using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
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
