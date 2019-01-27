using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour {
    
    public GameObject canvasEnding;
    public GameObject [] storyboardsEnd;
    public AudioClip[] storySoundsEnd;
    public bool activateBegin;
    public bool activateEnd;
    public GameObject father;

    AudioSource endSounds;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (activateBegin)
        {
            canvasEnding.SetActive(true);
            BeginStory();
            activateBegin = false;
        }
        if (activateEnd)
        {
            father.SetActive(false);
            canvasEnding.SetActive(true);
            EndStory();
        }
    }

    void BeginStory()
    {
        StartCoroutine(beginStory());
    }

    void EndStory()
    {
        StartCoroutine(endStory());
    }

    IEnumerator beginStory ()
    {
        for (int i = storyboardsEnd.Length - 2; i < storyboardsEnd.Length; i++)
        {
            storyboardsEnd[i].SetActive(true);
            yield return new WaitForSeconds(4);
            storyboardsEnd[i].SetActive(false);
        }
        canvasEnding.SetActive(false);

    }

    IEnumerator endStory ()
    {
        for (int i = 0; i < 9; i++)
        { 
            storyboardsEnd[i].SetActive(true);
            yield return new WaitForSeconds(4);
        }

    }
}
