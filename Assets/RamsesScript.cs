using UnityEngine;
using System.Collections;

public class RamsesScript : MonoBehaviour {

	private GameObject player;
	private PlayerController playerControllerScr;
	private float timer;
	private float speed;
	
	// Use this for initialization
	void Start () {
		timer = 0;
		speed = 5 * Time.deltaTime;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerControllerScr = player.GetComponent<PlayerController> ();
	}


	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (Mathf.Lerp (this.transform.position.x, player.transform.position.x, speed),
		                                 Mathf.Lerp (this.transform.position.y, player.transform.position.y, speed));

		print (transform.position + "playerPos " + player.transform.position);
		if (transform.position == player.transform.position) {
			//flicker
			timer += Time.deltaTime;
			if(timer >= 1.5f)
				playerControllerScr.CheckShape(1.0f , 1.0f, this.gameObject);

		}
	
	}
}
