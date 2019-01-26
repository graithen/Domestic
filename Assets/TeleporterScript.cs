using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterScript : MonoBehaviour {

    public GameObject teleportToObject;
    public GameObject teleportSubject;
    public GameObject roomCam;
   // public GameObject prevCam;
    //public Camera roomCam;
    private Rigidbody rb;
    public bool playerExitTeleporter = false;
    public bool enemyExitTeleporter = false;
    // Use this for initialization
    void Start () {
      //  roomCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerExitTeleporter == false)
        {
            //rb = other.GetComponent<Rigidbody>();
            teleportToObject.GetComponent<TeleporterScript>().playerExitTeleporter = true;
            other.transform.position = teleportToObject.transform.position;
            GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
            roomCam.SetActive(true);
            roomCam.tag = "MainCamera";
            //other.transform.position = teleportToObject.transform.position + new Vector3(rb.velocity.x, 0, rb.velocity.z)*250 ;
        }
        if (other.CompareTag("Enemy") && enemyExitTeleporter == false)
        {
            //rb = other.GetComponent<Rigidbody>();
            teleportToObject.GetComponent<TeleporterScript>().enemyExitTeleporter = true;
            other.GetComponent<FatherController>().DisableCollider();
            other.transform.position = teleportToObject.transform.position;
            //other.transform.position = teleportToObject.transform.position + new Vector3(rb.velocity.x, 0, rb.velocity.z)*250 ;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerExitTeleporter = false;
            
            //roomCam.enabled = true;
            
            
            //prevCam.SetActive(false);
          
            
        }
        if (other.CompareTag("Enemy"))
            enemyExitTeleporter = false;
    }
}
