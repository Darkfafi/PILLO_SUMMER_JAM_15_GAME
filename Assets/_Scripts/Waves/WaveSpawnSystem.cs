using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawnSystem : MonoBehaviour {

	private int wavesSpawned;
	private float timeBetweenSpawn;
	private float minTimeBetweenSpawn;
	private float timer;
	public float waveSpeed;
	public PlayerController player;

	private List<WaveType> _allWavesForLevel = new List<WaveType>(){};

	public int amountOfNormalShapesInLevel = 1;
	public int amountOfBlackShapesInLevel = 1;
	public float moveSpeedNormalShapesInLevel = 1;
	public float moveSpeedBlackShapesInLevel = 1;



	// Use this for initialization
	void Start () {
		minTimeBetweenSpawn = 1.5f;
		waveSpeed = -0.0005f;

		CreateWave (WaveType.NORMAL_SHAPE, amountOfNormalShapesInLevel, moveSpeedNormalShapesInLevel);
		CreateWave (WaveType.BLACK_SHAPE, amountOfBlackShapesInLevel, moveSpeedBlackShapesInLevel);

		//Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		variableTime ();
	}

	void variableTime()
	{
		timer += 1 * Time.deltaTime;
		timeBetweenSpawn = waveSpeed * Mathf.Pow(wavesSpawned, 2)+4.5f;
		
		if (timeBetweenSpawn <= minTimeBetweenSpawn)
		{
			timeBetweenSpawn = minTimeBetweenSpawn;
		}
		if (timer >= timeBetweenSpawn)
		{
			if(_allWavesForLevel.Count > 0){
				CreateTargetShape(_allWavesForLevel[0]);
				_allWavesForLevel.RemoveAt(0);
			}else{
				Debug.Log("NEXT LEVEL");
			}
		}
	}

	void CreateWave(string type, int amount,float speedWaveType){
		WaveType targetUnit;
		for (int i = 0; i < amount; i++) {
			targetUnit = new WaveType(type,speedWaveType);

			_allWavesForLevel.Add(targetUnit);
		}
		_allWavesForLevel = RandomnizeGList (_allWavesForLevel);
	}

	List<WaveType> RandomnizeGList(List<WaveType> list){
		List<WaveType> oldCloneList = list;
		List<WaveType> newList = new List<WaveType> (){};

		while (oldCloneList.Count > 0) {
			int index = Random.Range(0,oldCloneList.Count);
			newList.Add(oldCloneList[index]);
			oldCloneList.RemoveAt(index);
		}

		return newList;
	}

	void CreateTargetShape(WaveType shapeType){

		GameObject shapeObject;

		timer = 0;
		wavesSpawned += 1;

		//GameObject targetShape = (GameObject)Resources.Load("Prefaps/TargetShape");

		Vector3 tempScaleVec = new Vector3 (Random.Range (player._minSize.x,  player._maxSize.x), Random.Range (player._minSize.y, player._maxSize.y), 1);
		print (player._minSize + "max " + player._maxSize);


		Vector3 spawnPoint = new Vector3 (0,0,0);

		if (Random.Range (0, 2) > 0) {

			spawnPoint.x = Random.Range(1,Camera.main.pixelWidth);
			spawnPoint.y = Camera.main.pixelHeight * Random.Range(0,2);

		} else {
			spawnPoint.x = Camera.main.pixelWidth * Random.Range(0,2);
			spawnPoint.y = Random.Range(1,Camera.main.pixelHeight);
		}

		//targetShape.GetComponent<TargetForm> ().speed = 0.2f;

		shapeObject = Instantiate ((GameObject)Resources.Load("Prefaps/TargetShape"),Camera.main.ScreenToWorldPoint(spawnPoint),Quaternion.identity) as GameObject;
	
		shapeObject.transform.localScale = tempScaleVec;

		if (shapeType.type == WaveType.BLACK_SHAPE) {
			shapeObject.AddComponent<HiddenObject>();
		}
		shapeObject.GetComponent<TargetForm> ().speed = shapeType.speed;
	}
}
