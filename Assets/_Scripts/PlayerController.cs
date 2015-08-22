using UnityEngine;
using System.Collections;
using Pillo;

public class PlayerController : MonoBehaviour {

	#region variable/properties

	private float _sensitivityPilloOne;
	private float _sensitivityPilloTwo;
	public Vector3 _currentSize;
	public Vector3 _minSize;
	public Vector3 _maxSize;
	private float timerY;
	private float timerX;
	private PillowState _pillowOneState;
	private PillowState _pillowTwoState;
	public enum PillowState
	{
		RELEASED,
		PRESSED
	}
	private GameObject PlayerBody;
	private GameObject PlayerFace;

	#endregion

	// Use this for initialization
	void Start () {
		PilloController.ConfigureSensorRange(0x50, 0x6f);
		_minSize = new Vector3 (1, 1, 0);
		_maxSize = new Vector3 (3, 3, 0);
		_currentSize = this.transform.localScale;
		this.transform.localScale = new Vector3 (1, 1, 0);
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
		if (_currentSize.x > _maxSize.x)
		{
			_currentSize.x = _maxSize.x;
		}
		if (_currentSize.y > _maxSize.y)
		{
			_currentSize.y = _maxSize.y;
		}
		if (_pillowOneState == PillowState.PRESSED)
		{
			timerX = 0;
			_currentSize.x += 0.8f * Time.deltaTime;
			_currentSize.y -= 0.2f * Time.deltaTime;
		}
		else if (_pillowOneState == PillowState.RELEASED)
		{
			_currentSize.x -= 0.3f * Time.deltaTime;
			timerX += Time.deltaTime;
			if (timerX > 0.8f)
			{
				_currentSize.x = Mathf.Lerp(_currentSize.x, 1, 0.05f);
			}
		}
		if (_pillowTwoState == PillowState.PRESSED)
		{
			timerY = 0;
			_currentSize.y += 0.8f * Time.deltaTime;
			_currentSize.x -= 0.2f * Time.deltaTime;
		}
		else if (_pillowTwoState == PillowState.RELEASED)
		{
			_currentSize.y -= 0.3f * Time.deltaTime;
			timerY += Time.deltaTime;
			if (timerY > 0.8f)
			{
				_currentSize.y = Mathf.Lerp(_currentSize.y, 1, 0.05f);
			}
		}
		transform.localScale = _currentSize;
	}

	public void CheckShape (float scaleX, float scaleY, GameObject shape)
	{
		if (_currentSize.x > 0.8f * scaleX && 
		    _currentSize.x < 1.2f * scaleX && 
		    _currentSize.y > 0.8f * scaleY && 
		    _currentSize.y < 1.2f * scaleY) {
			Destroy(shape);
			UpdateFaceTexture("blij1");
			// scorepoint()
		} else {
			UpdateFaceTexture("sad1");
		//badstuff
		}
		Destroy(shape);
	}

	private void UpdateTexture(string textureName)
	{
		Sprite sprite = Resources.Load (textureName, typeof(Sprite)) as Sprite;
		this.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	private void UpdateFaceTexture(string textureName)
	{
		Sprite sprite = Resources.Load (textureName, typeof(Sprite)) as Sprite;
		this.GetComponentInChildren<SpriteRenderer> ().sprite = sprite;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
	}
}
