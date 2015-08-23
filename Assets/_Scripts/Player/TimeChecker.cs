using UnityEngine;
using System.Collections;

public class TimeChecker : MonoBehaviour {

	private float timerPillowOne;
	private float timerPillowTwo;
	private float sensitivityPillowOne;
	private float sensitivityPillowTwo;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		sensitivityPillowOne = PilloController.GetSensor (Pillo.PilloID.Pillo1);
		sensitivityPillowTwo = PilloController.GetSensor (Pillo.PilloID.Pillo2);
		if (sensitivityPillowOne == 1.0f) {
			timerPillowOne += Time.deltaTime;
		}
		if (sensitivityPillowTwo == 1.0f) {
			timerPillowTwo += Time.deltaTime;
		}
		if (timerPillowOne >= 3.0f && timerPillowTwo <= 3.0f)
		{
			//playertextures 1
		}
		if (timerPillowTwo >= 3.0f && timerPillowOne <= 3.0f) 
		{
			//playertextures 2
		}
		if (timerPillowOne >= 3.0f && timerPillowTwo >= 3.0f)
		{
			//random
			float random = Random.Range(1,10);
			if(random > 5)
			{
				//playerOne
			}else{
				//playerTwo
			}
		}
	}
}
