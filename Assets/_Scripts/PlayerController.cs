using UnityEngine;
using System.Collections;
using Pillo;

public class PlayerController : MonoBehaviour {

	#region variable/properties

	private float _sensitivityPilloOne;
	private float _sensitivityPilloTwo;
	public  Vector3 _currentSize;
	public Vector3 _minSize;
	public Vector3 _maxSize;
	private PillowState _pillowOneState;
	private PillowState _pillowTwoState;

	private float scaler = 0.05f;
	private float minusscaler = -0.05f;
	public enum PillowState
	{
		RELEASED,
		PRESSED
	}
	#endregion

	// Use this for initialization
	void Start () {
		PilloController.ConfigureSensorRange(0x50, 0x6f);
	}

	// Update is called once per frame
	void Update () {
		UpdatePillowState ();
		UpdateCurrentSize ();
	}


	private void UpdatePillowState()
	{
		_sensitivityPilloOne = PilloController.GetSensor (PilloID.Pillo1);
		_sensitivityPilloTwo = PilloController.GetSensor (PilloID.Pillo2);
		if(_sensitivityPilloOne >= 1)
		{
			_pillowOneState = PillowState.PRESSED;
		}
		else
		{
			_pillowOneState = PillowState.RELEASED;
		}
		if(_sensitivityPilloTwo >= 1)
		{
			_pillowTwoState = PillowState.PRESSED;
		}
		else
		{
			_pillowTwoState = PillowState.RELEASED;
		}
	}
	private void UpdateCurrentSize()
	{
		_currentSize = this.transform.localScale;

		if (_pillowOneState == PillowState.PRESSED && _pillowTwoState == PillowState.PRESSED && 
		    this.transform.localScale.x < _maxSize.x && this.transform.localScale.y < _maxSize.y )
		{


		} else if(_pillowOneState == PillowState.PRESSED && _pillowTwoState == PillowState.RELEASED && 
		          this.transform.localScale.x <= _maxSize.x && this.transform.localScale.y >= _minSize.y )
		{
			float x = _currentSize.x + _currentSize.x * scaler;
			float y = _currentSize.y + _currentSize.y * minusscaler;
			this.transform.localScale = new Vector3(x, y, 0);
			Debug.Log(_currentSize);
		}
		else if(_pillowOneState == PillowState.RELEASED && _pillowTwoState == PillowState.PRESSED &&
		        this.transform.localScale.x > _minSize.x && this.transform.localScale.y < _maxSize.y){
		}
		else if(_pillowOneState == PillowState.RELEASED && _pillowTwoState == PillowState.RELEASED &&
		        this.transform.localScale.x < _minSize.x && this.transform.localScale.y < _minSize.y)
		{
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
	}
}
