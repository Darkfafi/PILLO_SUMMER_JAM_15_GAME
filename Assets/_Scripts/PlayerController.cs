using UnityEngine;
using System.Collections;
using Pillo;

public class PlayerController : MonoBehaviour {

	#region variable
	private float _sensitivityPilloOne;
	private float _sensitivityPilloTwo;

	public enum CurrentState
	{
		RESTSTATE,
		PRESSEDSTATE,
	}

	public CurrentState state;
	#endregion

	// Use this for initialization
	void Start () {
		PilloController.ConfigureSensorRange(0x50, 0x6f);
	}

	// Update is called once per frame
	void Update () {
		_sensitivityPilloOne = PilloController.GetSensor (PilloID.Pillo1);
		_sensitivityPilloTwo = PilloController.GetSensor (PilloID.Pillo2);
		//test info 
		Debug.Log (_sensitivityPilloOne);
	}
	
	private GameObject FindGameObjectInRange()
	{
		RaycastHit hit;
		//Player now will know if an object is interactable if the raycast hits.
		if (Physics.Raycast (transform.position, fwd, out hit, maxDistance) && hit.transform.tag == "InterActive") {

		}
		return null;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
	}
}
