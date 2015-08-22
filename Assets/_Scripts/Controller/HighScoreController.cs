using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HighScoreController : MonoBehaviour {

	private int _playTimeAmountOfMatches;
	private int _levelAmountOfMatches;
	private int _totalAmountOfMatches;
	// Use this for initialization
	void Start () {
		_playTimeAmountOfMatches = 0;
		_totalAmountOfMatches = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void IncreaseAmountOfMatches()
	{
		++_playTimeAmountOfMatches;
		++_levelAmountOfMatches;
		print ("level " + _levelAmountOfMatches + " playtime " + _playTimeAmountOfMatches);
	}

	public int GetCurrentLevelAmountOfMatches ()
	{
		return _levelAmountOfMatches;
	}

	public int GetCurrentPlayTimeAmountOfMatches()
	{
		return _playTimeAmountOfMatches;
	}

	public void ResetLevelAmountOfMatches()
	{
		_levelAmountOfMatches = 0;
	}
	public void ResetPlayTimeAmountOfMatches()
	{
		_playTimeAmountOfMatches = 0;
	}

}
