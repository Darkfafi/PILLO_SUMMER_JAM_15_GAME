using UnityEngine;
using System.Collections;

public class LevelSystem : MonoBehaviour {

	WaveSpawnSystem waveSpawn;

	// Use this for initialization
	void Start () {
		waveSpawn = GetComponent<WaveSpawnSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
