using UnityEngine;
using System.Collections;

public class TargetForm : MonoBehaviour {

	public float speed = 0;

	Vector3 startPos;
	GameObject target;

	void Start(){
		target = GameObject.FindGameObjectWithTag("Player");
		startPos = transform.position;
	}

	void Update(){
		Vector2 dir = new Vector2 (target.transform.position.x - transform.position.x,target.transform.position.y - transform.position.y);
		float realSpeed = (((transform.position.magnitude / startPos.magnitude) +  0.35f) * speed) * Time.deltaTime;
		dir.Normalize ();
		transform.position = new Vector3(transform.position.x + dir.x * realSpeed,transform.position.y + dir.y * realSpeed,0);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<PlayerControll> () != null) {
			//TODO verander zodat het script van Patrick wordt aangeroepen.
			PlayerControll plrCtr = other.gameObject.GetComponent<PlayerControll> ();
			//plrCtr.CheckFormCorrect(this.transform);
		}
	}
}
