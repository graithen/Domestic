using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FatherController : MonoBehaviour {
    public GameObject spawnLocation;
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject player;
    public GameObject[] patrolOne;
    public GameObject[] patrolTwo;
    public GameObject[] patrolThree;
    public GameObject[][] patrols = new GameObject[3][];
    int currentRoom = 0;
    int currentPatrol;
	// Use this for initialization
	void Start () {
        patrols[0] = patrolOne;
        patrols[1] = patrolTwo;
        patrols[2] = patrolThree;
        currentPatrol = Mathf.RoundToInt(Random.Range(-0.5f, 2.49f));
        target = patrols[currentPatrol][currentRoom];
    }

    // Update is called once per frame
    void Update() {
        playerCheck(player);
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        agent.SetDestination(target.transform.position);
        if (!patrols[currentPatrol][currentRoom].Equals(target))
        {
            if (Vector3.Distance(target.transform.position, gameObject.transform.position) < 2)
            {
                target = patrols[currentPatrol][currentRoom];
            }
        }
        else
            if (Vector3.Distance(patrols[currentPatrol][currentRoom].transform.position, gameObject.transform.position) < 2)
            {
                if (currentRoom < patrolOne.Length - 1)
                {
                    currentRoom += 1;
                    target = patrols[currentPatrol][currentRoom];
                }
                else
                {
                    currentRoom = 0;
                    currentPatrol = Mathf.RoundToInt(Random.Range(-0.5f, 2.49f));
                    target = patrols[currentPatrol][currentRoom];
                }
            }
    }

    public void DisableCollider()
    {
        StartCoroutine(disableCollider());
    }

    public void ResetGame()
    {
        StartCoroutine(resetGameWait());
    }

    IEnumerator disableCollider()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }

    IEnumerator resetGameWait()
    {
        yield return new WaitForSeconds(2.5f);
        resetGame();
    }

    void attack()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z + 1.0f);
        player.GetComponent<PlayerController>().enabled = false;
        DisableCollider();
        ResetGame();
    }

    void resetGame()
    {
        gameObject.transform.position = spawnLocation.transform.position;
        currentRoom = 0;
        currentPatrol = Mathf.RoundToInt(Random.Range(-0.5f, 2.49f));
        target = patrols[currentPatrol][currentRoom];
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerController>().reset();
    }

    void playerCheck(GameObject player)
    {
        bool hidden = player.GetComponent<PlayerController>().isHidden;
        if (!hidden)
        {
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 2)
            {
                attack();
            }
            if (Vector3.Distance(player.transform.position, gameObject.transform.position) < 10)
            { 
                 target = player;              
            }
        }
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > 100)
            target = patrols[currentPatrol][currentRoom];
    }
}
