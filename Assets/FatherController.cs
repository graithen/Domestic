using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FatherController : MonoBehaviour {
    public NavMeshAgent agent;
    public GameObject target;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        agent.SetDestination(target.transform.position);
    }

    /*public void DisableCollider()
    {
        StartCoroutine(disableCollider());
    }

    IEnumerator disableCollider()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }*/
}
