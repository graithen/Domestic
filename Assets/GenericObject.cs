using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObject : MonoBehaviour
{
    PlayerController controller;
    bool interactOpen;

    public bool phoneBook;
    public bool key;
    public GameObject studyDoor;
    public GameObject studyTeleporter;
    public GameObject mainCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactOpen)
        {
            Interact();
        }
    }

    private void Interact ()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Object interaction code:
            if (phoneBook && !controller.phoneBook)
            {
                controller.phoneBook = true;
                Destroy(gameObject);
            }
            if (key && controller != null && !controller.key)
            {
                controller.key = true;
                studyDoor.SetActive(false);
                studyTeleporter.SetActive(true);
                Destroy(gameObject);
            }
            if (!phoneBook && !key && controller.phoneBook)
            {
                mainCamera.GetComponent<Ending>().activateEnd = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player entered");
            controller = other.GetComponent<PlayerController>();
            interactOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player exited");
            interactOpen = false;
        }
    }
}