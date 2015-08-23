using UnityEngine;
using System.Collections;

public class WaveSpawnSystem : MonoBehaviour {

	private int wavesSpawned;
	private float timeBetweenSpawn;
	public float minTimeBetweenSpawn;
	private float timer;
	public float waveSpeed;
	public PlayerController player;
	public float speedChangeMin;
	public float speedChangeMax;
	public float waitTime;
	private float speedChange;
	// Use this for initialization
	void Start () {
		minTimeBetweenSpawn = 1.5f;
		waveSpeed = -0.0005f;
		
		//Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		variableTime ();
	}

	void variableTime()
	{
		timer += 1 * Time.deltaTime;
		timeBetweenSpawn = waveSpeed * Mathf.Pow(wavesSpawned, 2)+waitTime;
		
		if (timeBetweenSpawn <= minTimeBetweenSpawn)
		{
			timeBetweenSpawn = minTimeBetweenSpawn;
		}
		if (timer >= timeBetweenSpawn)
		{
			CreateTargetShape();
		}
	}

	void CreateTargetShape(int difficulty = 1){

		timer = 0;
		wavesSpawned += 1;

		GameObject targetShape = (GameObject)Resources.Load("Prefaps/TargetShape");

		Vector3 tempScaleVec = new Vector3 (Random.Range (player._minSize.x,  player._maxSize.x), Random.Range (player._minSize.y, player._maxSize.y), 1);
		print (player._minSize + "max " + player._maxSize);
		targetShape.transform.localScale = tempScaleVec;

		Vector3 spawnPoint = new Vector3 (0,0,10);

		if (Random.Range (0, 2) > 0) {

			spawnPoint.x = Random.Range(1,Camera.main.pixelWidth);
			spawnPoint.y = Camera.main.pixelHeight * Random.Range(0,2);

		} else {
			spawnPoint.x = Camera.main.pixelWidth * Random.Range(0,2);
			spawnPoint.y = Random.Range(1,Camera.main.pixelHeight);
		}
		speedChange = Random.Range(speedChangeMin,speedChangeMax);
		targetShape.GetComponent<TargetForm> ().speed = speedChange;
		Instantiate (targetShape,Camera.main.ScreenToWorldPoint(spawnPoint),Quaternion.identity);
	}
}
