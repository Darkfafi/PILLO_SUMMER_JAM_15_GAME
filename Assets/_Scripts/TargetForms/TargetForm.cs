using UnityEngine;
using System.Collections;

public class TargetForm : MonoBehaviour {

	public const string UNREVEALED_FORM =  "UnrevealedForm";
	
	public string currentForm; //maak de vormen via een factory patern en geef ze hun form en art mee.
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<PlayerControll> () != null) {
			PlayerControll plrCtr = other.gameObject.GetComponent<PlayerControll> ();
			plrCtr.CheckFormCorrect(this);
		}
	}
}
