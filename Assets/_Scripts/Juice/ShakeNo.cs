using UnityEngine;
using System.Collections;

public class ShakeNo : MonoBehaviour {
	float timer;
    float amp = 0f;
    Vector3 startPos;

    // Use this for initialization
    void Start () 
	{
        timer = Random.Range(0, 360);
        startPos = transform.position;
    }
	
	public void DoShake()
	{
        amp = 1.5f;
    }
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		
        Vector3 newPos = transform.position;
		newPos.x += Mathf.Sin(timer * 20.0f) * amp;
        amp *= 0.95f;
        transform.position = newPos;
		
		if (amp < 0.01f)
		{
            transform.position = startPos;
        }

    }
}
