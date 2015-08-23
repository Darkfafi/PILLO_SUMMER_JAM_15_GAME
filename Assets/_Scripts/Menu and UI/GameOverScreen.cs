using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Pillo;

public class GameOverScreen : MonoBehaviour {




	private string currentlevel;
	public bool isGameOver;
	public List<Vector3> levelPositions = new List<Vector3>();
	public GameObject parcle;
	bool instantiated;

	void Awake () {
		instantiated = false;
		GameObject[] nodes = GameObject.FindGameObjectsWithTag("levelPos");

		foreach (GameObject n in nodes)
		{
			levelPositions.Add(n.transform.position);
		}

		int LoadedIndexWithModifier = Application.loadedLevel - 1;
		//currentlevel = LoadedIndexWithModifier.ToString();

		isGameOver = false;
	}
	
	void Update () {
	


			if(isGameOver)
		{

			int LoadedIndexWithModifier = 9 - Application.loadedLevel;
			Time.timeScale = 0.5f;

			if (!instantiated)
			{
			GameObject ParcleInstance = Instantiate (parcle, Camera.main.ScreenToWorldPoint(new Vector3( -1,levelPositions[0].y, 1)), Quaternion.identity) as GameObject;
			/*ParcleInstance.transform.position = new Vector3 (Mathf.Lerp(ParcleInstance.transform.position.x, levelPositions[LoadedIndexWithModifier].x, 1),
			                                                 ParcleInstance.transform.position.y, 
			                                                 ParcleInstance.transform.position.z);*/


			ParcleInstance.transform.position = levelPositions[LoadedIndexWithModifier];
				instantiated = true;
			}
			//GetComponentInChildren<Text>().text = "Level "+ currentlevel;

		}	

			// replace <PillowAxis1> and <PillowAxis2> with actual pillow controlls
		if ( PilloController.GetSensor (PilloID.Pillo1) > 0 && PilloController.GetSensor (PilloID.Pillo2) > 0)
			{
				isGameOver = false;
				Time.timeScale = 1;
				Application.LoadLevel (0);


			}
		}





}

