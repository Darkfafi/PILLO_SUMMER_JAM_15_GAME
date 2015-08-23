using UnityEngine;
using System.Collections;

public class BreatheScript : MonoBehaviour {
	float timer;

	// Use this for initialization
	void Start () 
	{
        timer = Random.Range(0, 360);
    }
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		
        Vector3 newScale = transform.localScale;
		newScale.x += Mathf.Sin(timer * 4.2f) * 0.01f;
        newScale.y += Mathf.Cos(timer * 3.8f) * 0.01f;
		transform.localScale = newScale;

        Vector3 newRotation = transform.eulerAngles;
		newRotation.z += Mathf.Sin(timer * 4.5f + 180) * 0.15f;
        transform.eulerAngles = newRotation;

    }
}
