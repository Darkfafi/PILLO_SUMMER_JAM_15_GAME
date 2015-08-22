using UnityEngine;
using System.Collections;

public class Easing : MonoBehaviour {
    float StartX;
    float DestinationX;
    float Timer = 0;
    float EaseDuration;

    // Use this for initialization
    void Start () 
	{
        StartX = transform.position.x;
        DestinationX = -StartX;
        EaseDuration = 2f;
    }
	
	// Update is called once per frame
	void Update () 
	{
        Timer += Time.deltaTime;
        transform.position = new Vector3(ElasticEaseOut(Timer, StartX, DestinationX, EaseDuration), transform.position.y, transform.position.z);
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
        if ((t /= d) == 1)
        {
            return b + c;
        }

        float p = d * 0.3f;
		float s = p / 4;

		return ( c * Mathf.Pow( 2, -10 * t ) * Mathf.Sin( ( t * d - s ) * ( 2 * Mathf.PI ) / p ) + c + b );
	}
}
