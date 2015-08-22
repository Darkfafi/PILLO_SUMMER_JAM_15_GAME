using UnityEngine;
using System.Collections;

public class TargetForm : MonoBehaviour {

	public float speed = 0;

	private Vector3 startPos;
	private PlayerController target;
	private float timer;
	public float range;

	void Start(){
		target = (PlayerController)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController");
		startPos = transform.position;

		range = 0.02f;
	}

	void Update(){
		Vector2 dir = new Vector2 (target.transform.position.x - transform.position.x,target.transform.position.y - transform.position.y);
		float realSpeed = (((transform.position.magnitude / startPos.magnitude) +  0.35f) * speed) * Time.deltaTime;
		dir.Normalize ();
		transform.position = new Vector3(transform.position.x + dir.x * realSpeed,transform.position.y + dir.y * realSpeed, 0.015f);
		if (InRange()) {
			OnPosition();
		}
	}

	private bool InRange()
	{
		Vector3 minRange = new Vector3 (target.transform.position.x - range, target.transform.position.y - range, 0);
		Vector3 maxRange = new Vector3 (target.transform.position.x + range, target.transform.position.y + range, 0);
		if (this.transform.position.x > minRange.x && this.transform.position.y > minRange.y && 
		    this.transform.position.x < maxRange.x && this.transform.position.y < maxRange.y) {

			return true;
		}
		return false;
	}

	private void OnPosition()
	{
			timer += Time.deltaTime;
			if(timer >= 0.8f)
				target.CheckShape(this.gameObject);
	}
}
