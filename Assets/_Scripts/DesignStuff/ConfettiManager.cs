using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConfettiManager : MonoBehaviour {
    private GameObject[] Confettis;

    // Use this for initialization
    void Start () 
	{
        Confettis = GameObject.FindGameObjectsWithTag("Confetti");
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
            print("fffsdf");
            foreach (GameObject o in Confettis)
			{
                o.SetActive(true);
                o.GetComponent<Confetti>().MakeConfetti();
            }
		}
	}
}
