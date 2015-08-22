using UnityEngine;
using System.Collections;

public class HiddenObject : MonoBehaviour {

	private Vector2 _trueShape;

	// Use this for initialization
	void Start () {
		_trueShape = new Vector2 (transform.localScale.x,transform.localScale.y);
		HideForm ();
	}
	
	// Update is called once per frame
	void Update () {
		float pillo1Shake = PilloController.GetAccelero (Pillo.PilloID.Pillo1).magnitude;
		float pillo2Shake = PilloController.GetAccelero (Pillo.PilloID.Pillo2).magnitude;
		if (pillo1Shake < 900 && pillo1Shake != 0 || pillo1Shake > 1100) {
			ChangeToTrueForm();
		}
	}

	void HideForm(){
		transform.localScale = new Vector3 (2, 2, 1);
		if (GetComponent<SpriteRenderer> () != null) {
			GetComponent<SpriteRenderer> ().color = Color.black;
		}
	}

	void ChangeToTrueForm(){
		transform.localScale = new Vector3 (_trueShape.x, _trueShape.y, 1);
		if (GetComponent<SpriteRenderer> () != null) {
			GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
}
