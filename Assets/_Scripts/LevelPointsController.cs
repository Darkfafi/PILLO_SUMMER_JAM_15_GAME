using UnityEngine;
using System.Collections;

public class LevelPointsController : MonoBehaviour {

	public int life;
	private GameObject gameOverScreen;
	public int pointsToComplete;
	public GameObject parcle;
	private int currentPoints;


	// Use this for initialization
	void Start () {

		gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen"); 
		gameOverScreen.SetActive(false);
	
	}

	void UpdatePoints()
	{
		if ( life < 1)
			GameOver();

		if ( currentPoints >= pointsToComplete)
			CompleteLevel();
	}

	void CompleteLevel()
	{

	}


 	public void decrLife()
	{
		life --;
	}

	public void incrPoints()
	{
		currentPoints++;
		GameObject parcleInstance = Instantiate (parcle, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		Destroy (parcleInstance, 0.5f);
	}

	private void GameOver()
	{
		gameOverScreen.SetActive(true);
		gameOverScreen.GetComponent<GameOverScreen>().isGameOver = true;
	}


	void Update () {
	
		UpdatePoints();
	}
}
