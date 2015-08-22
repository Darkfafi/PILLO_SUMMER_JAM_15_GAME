using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarController : MonoBehaviour {
    private GameObject[] Stars;

    // Use this for initialization
    void Start () 
	{
        Stars = GameObject.FindGameObjectsWithTag("Star");
    }
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.C))
		{
            print("fffsdf");
            foreach (GameObject o in Stars)
			{
                o.SetActive(true);
                o.GetComponent<Star>().MakeStars();
            }
		}
	}
}
