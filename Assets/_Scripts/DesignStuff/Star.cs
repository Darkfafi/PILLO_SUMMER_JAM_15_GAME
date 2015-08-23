using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
    float speed;
	float speedY;
	float speedX;
    float startSpeedY;
    Vector3 newPosition;

    float timer = 0;

    // Use this for initialization
    void Start () 
	{
        MakeStars();
    }
    
    public void MakeStars()
    {
        gameObject.SetActive(true);
        
        transform.position = transform.parent.position;

        transform.eulerAngles = new Vector3(0,0,Random.Range(0,360));
        speed = Random.Range(0.1f, 0.3f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        newPosition = transform.position;

        timer = Random.Range(0f, 361f);
		
		
    }
	
	// Update is called once per frame
	void Update () 
	{
        timer++;
		
        newPosition = transform.position;

        newPosition.y -= speedY;
        newPosition.x += speedX;
        
		if (speedY > 0.02f)
		{
			newPosition.x += Mathf.Sin(timer * 0.3f) * 0.02f;
		}
        if (speed < 0.05f)
		{
            GetComponent<SpriteRenderer>().color = new Color(1,1,1, GetComponent<SpriteRenderer>().color.a * 0.8f);
            if (GetComponent<SpriteRenderer>().color.a < 0.001f)
			{
                gameObject.SetActive(false);
            }
        }

        speed *= 0.94f;
        transform.position += transform.up * speed;
    }
}
