using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	WaveSpawnSystem waveSpawn;
	private HighScoreController highScoreController;
	// Use this for initialization
	void Start () {
		waveSpawn = GetComponent<WaveSpawnSystem> ();
		highScoreController = (GameObject.FindGameObjectWithTag ("HighScoreController").GetComponent ("HighScoreController") as HighScoreController);
	}
	
	// Update is called once per frame
	void Update () {
		if(highScoreController.GetCurrentLevelAmountOfMatches() >= 5)
		{
			CompleteLevel();
		}
		if (highScoreController.GetCurrentPlayTimeAmountOfMatches() >= 10) 
		{
			GameOver();
		}
	}

	public void CompleteLevel()
	{
		highScoreController.ResetLevelAmountOfMatches ();
		print ("Yah Level complete");
	}

	public void GameOver()
	{
		print ("GameOver"); 
	}
}
