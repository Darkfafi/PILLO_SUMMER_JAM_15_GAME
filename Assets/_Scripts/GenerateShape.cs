using UnityEngine;
using System.Collections;

public class GenerateShape : MonoBehaviour {

	private GameObject player;
	private Vector3 startScale;
	private Vector3 playerScale;
    private float timerY;
    private float timerX;
    private bool canBounce;
	private float maxX;
    private float maxY;
    private float duration = 10;



    // Use this for initialization
    void Start () {
		startScale = new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), 1f);
        transform.localScale = startScale;
        player = GameObject.FindGameObjectWithTag("Player");
        playerScale = new Vector3(1, 1, 1);
        maxX = 3.5f;
        maxY = 3.5f;

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Input.GetAxis("Horizontal"));

        if (playerScale.x > maxX)
        {
            playerScale.x = maxX;
        }
		 if (playerScale.y > maxY)
        {
            playerScale.y = maxY;
        }
		
        if (Input.GetAxis("Horizontal") > 0)
        {

            timerX = 0;
            Debug.Log("x");
            playerScale.x += 0.8f * Time.deltaTime;
            playerScale.y -= 0.2f * Time.deltaTime;
        }
		
		if (Input.GetAxis("Vertical") > 0)
        {
			timerY = 0;
            playerScale.y += 0.8f * Time.deltaTime;
			playerScale.x -= 0.2f * Time.deltaTime;
            Debug.Log("y");
        }

        if (Input.GetAxis("Vertical") == 0)
        {


            timerX += Time.deltaTime;
            if (timerX > 1.5f)
            {
				for(float t = 0; t < duration; t++){
                    //playerScale.x = ElasticEaseOut(t, playerScale.x , 1f, 10f);
                    playerScale.x = Mathf.Lerp(playerScale.x, 1, 0.08f);
                    print("kra");
                }
                

            }
           
        }
		
		

        if (playerScale.x > startScale.x * 0.8f &&
			playerScale.x < startScale.x * 1.2f &&
            playerScale.y > startScale.y * 0.8f &&
            playerScale.y < startScale.y * 1.2f) {
            	//startgame ();
            	print("START");
            Camera.main.GetComponent<CameraShake>().Shake(0.08f);
        }
		player.transform.localScale = playerScale;
    }
	
	/// <summary>
	/// Easing equation function for an elastic (exponentially decaying sine wave) easing out: 
	/// decelerating from zero velocity.
	/// </summary>
	/// <param name="t">Current time in seconds.</param>
	/// <param name="b">Starting value.</param>
	/// <param name="c">Final value.</param>
	/// <param name="d">Duration of animation.</param>
	/// <returns>The correct value.</returns>
	public static float ElasticEaseOut( float t, float b, float c, float d )
	{
		if ( ( t /= d ) == 1 )
			return b + c;

		float p = d * 0.3f;
		float s = p / 4;

		return ( c * Mathf.Pow( 2, -10 * t ) * Mathf.Sin( ( t * d - s ) * ( 2 * Mathf.PI ) / p ) + c + b );
	}

}
