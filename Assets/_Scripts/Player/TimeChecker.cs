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
		if (sensitivityPillowOne >= 0.5f) {
			timerPillowOne += Time.deltaTime;
			print(timerPillowOne + "pilloOne");
		}
		if (sensitivityPillowTwo >= 0.5f) {
			timerPillowTwo += Time.deltaTime;
			print(timerPillowTwo + "pilloTwo");
		}

		if (timerPillowOne >= 3.0f && timerPillowTwo >= 3.0f)
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Settings"));
			//random
			float random = Random.Range(1,10);
			if(random > 5)
			{
				Application.LoadLevel("");
				print ("1.1");
				//playerOne
			}else{
				//playerTwo
				Application.LoadLevel("");
				print ("2.1");
			}
		if (timerPillowOne >= 3.0f && timerPillowTwo <= 3.0f)
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Settings"));

			Application.LoadLevel("");
			//playertextures 1
			print ("1");
		}
		if (timerPillowTwo >= 3.0f && timerPillowOne <= 3.0f) 
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Settings"));
			//playertextures 2
			Application.LoadLevel("");
			print ("2");
		}

		}
	}
}
