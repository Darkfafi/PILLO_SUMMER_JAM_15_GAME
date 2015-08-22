using UnityEngine;
using System.Collections;

public class Confetti : MonoBehaviour {
    float speedY;
	float speedX;
    float startSpeedY;
    Vector3 newPosition;

    float timer = 0;

    // Use this for initialization
    void Start () 
	{
        MakeConfetti();
    }
    
    public void MakeConfetti()
    {
        gameObject.SetActive(true);
        
        transform.position = transform.parent.position;
        newPosition = transform.position;
        speedY = -Random.Range(0.3f, 0.45f);
        speedX = -Random.Range(-0.1f, 0.1f);
        startSpeedY = speedY;

        timer = Random.Range(0f, 360f);

        int random = Random.Range(1, 4);
		
		switch (random)
		{
			case 1:
				GetComponent<SpriteRenderer>().color = new Color(91 / 255,158 / 255,170 / 255, 1);
            break;
			case 2:
				GetComponent<SpriteRenderer>().color = new Color(136 / 255,189 / 255,196 / 255, 1);
            break;
			case 3:
				GetComponent<SpriteRenderer>().color = new Color(242 / 255,228 / 255,181 / 255, 1);
            break;
            case 4:
				GetComponent<SpriteRenderer>().color = new Color(235,127,90, 1);
            break;
            case 5:
				GetComponent<SpriteRenderer>().color = new Color(138,139,98, 1);
            break;
        }
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
		
        speedY += 0.03f;
        speedX *= 0.97f;
        if (speedY > 0.05f)
		{
            speedY = 0.05f;
			if (!GetComponent<SpriteRenderer>().isVisible)
			{
                gameObject.SetActive(false);
            }
        }
        

        transform.position = newPosition;
    }
}
