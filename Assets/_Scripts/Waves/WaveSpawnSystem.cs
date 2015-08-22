using UnityEngine;
using System.Collections;

public class WaveSpawnSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CreateTargetShape ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void CreateTargetShape(int difficulty = 1){
		GameObject targetShape = (GameObject)Resources.Load("Prefaps/TargetShape");

		Vector3 tempScaleVec = new Vector3 (Random.Range (10, 20), Random.Range (10, 20), 1);

		targetShape.transform.localScale = tempScaleVec;

		Vector3 spawnPoint = new Vector3 (0,0,10);

		if (Random.Range (0, 2) > 0) {

			spawnPoint.x = Random.Range(1,Camera.main.pixelWidth);
			spawnPoint.y = Camera.main.pixelHeight * Random.Range(0,2);

		} else {
			spawnPoint.x = Camera.main.pixelWidth * Random.Range(0,2);
			spawnPoint.y = Random.Range(1,Camera.main.pixelHeight);
		}

		targetShape.GetComponent<TargetForm> ().speed = 3;

		Instantiate (targetShape,Camera.main.ScreenToWorldPoint(spawnPoint),Quaternion.identity);
	}
}
