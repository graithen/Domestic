using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().isHidden = true;
            Debug.Log("Player is hidden");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().isHidden = false;
            Debug.Log("Player is not hidden");
        }
    }
}
