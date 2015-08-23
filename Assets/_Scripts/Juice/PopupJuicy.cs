using UnityEngine;
using System.Collections;

public class PopupJuicy : MonoBehaviour {
    float timer = 0;
    float start = 0;
    float destination = 1;
    float totaltime = 2;


    // Use this for initialization
    void Start () 
	{
        transform.localScale = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () 
	{
        timer += Time.deltaTime;
		
        float s = Easing.ElasticEaseOut(timer, start, destination, totaltime);

        transform.localScale = new Vector3(s, s, s);
		
		if (timer >= 3)
		{
            print("LOAD NEW LEVEL NAO");
        }
    }
}
