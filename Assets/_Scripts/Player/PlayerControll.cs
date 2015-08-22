using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

	PlayerTransformer playerTransformer;

	// Use this for initialization
	void Start () {
		// Hier de kussens logica, listeners naar de delegates en alles.
		playerTransformer = GetComponent<PlayerTransformer> ();

		playerTransformer.currentForm = PlayerTransformer.FORM_DEFAULT;
	}
	/*
	public void CheckFormCorrect(TargetForm target){
		if(target.currentForm == playerTransformer.currentForm){
			Debug.Log("Score");
		}else{
			Debug.Log("Lose Life");
		}
	}*/


	/*
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<TargetTestForm> () != null) {
			TargetTestForm targetTestForm = other.gameObject.GetComponent<TargetTestForm> ();

			if(targetTestForm == playerTransformer.currentForm){
				Debug.Log("Score");
			}else{
				Debug.Log("Lose Life");
			}
		}
	}*/
}
