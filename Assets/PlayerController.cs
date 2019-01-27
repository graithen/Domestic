using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    public bool isHidden;
    public GameObject stealthIndicator;
    public GameObject spawnLocation;
    public GameObject startingCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();

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
