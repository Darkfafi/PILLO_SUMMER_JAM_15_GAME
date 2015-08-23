using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {

	// put on the image gameobject the tag "GameOverScreen"
	#region put this in another script and invoke it if the game is over;

	
	private GameObject gameOverScreen;

	void start()
	{
		gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen"); 
		gameOverScreen.SetActive(false);
	}
	
	
	private void GameOver()
	{
		gameOverScreen.SetActive(true);
		gameOverScreen.GetComponent<GameOverScreen>().isGameOver = true;
	}
	
	#endregion


	private string currentlevel;
	public bool isGameOver;

	void Start () {
	
	// since the level itself is not equal to the index of the scene index you need to modify this
		// replace '1' with the build's correct index modifier
		int LoadedIndexWithModifier = Application.loadedLevel - 1;
		currentlevel = LoadedIndexWithModifier.ToString();

//		GameOver = false;
	}
	
	void Update () {
	


///			if(GameOver)
	//	{
	//		Time.timeScale = 0.5f;
	//		GetComponentInChildren<Text>().text = "Level "+ currentlevel;
	//	}	

			// replace <PillowAxis1> and <PillowAxis2> with actual pillow controlls
		//	if ( <PillowAxis1> == 1 && <PillowAxis2> == 1)
	//		{
	//			GameOver = false;
	//			Time.timeScale = 1;
	//			Application.LoadLevel (0);
		//

	//		}
		}





}

