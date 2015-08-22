using UnityEngine;
using System.Collections;
using Pillo;

public class PlayerController : MonoBehaviour {

	#region variable/properties

	private float _sensitivityPilloOne = 0;
	private float _sensitivityPilloTwo = 0;
	public Vector3 _currentSize;
	public Vector3 _minSize;
	public Vector3 _maxSize;
	private float timerY;
	private float timerX;
	private PillowState _pillowOneState;
	private PillowState _pillowTwoState;
	private float range;

    public enum PillowState
	{
		RELEASED,
		PRESSED
	}
	
	public GameObject PlayerBody;
	public GameObject PlayerFace;
	#endregion

	// Use this for initialization
	void Start () {
		PilloController.ConfigureSensorRange(0x50, 0x6f);
		_minSize = new Vector3 (1, 1, 0);
		_maxSize = new Vector3 (3, 3, 0);
		range = 0.3f;
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
		//if controller is enabled do stuff
		_sensitivityPilloOne = Mathf.Min(1f, PilloController.GetSensor(PilloID.Pillo1) + (Input.GetAxis("Horizontal1") + 1f) / 2f);
		_sensitivityPilloTwo = Mathf.Min(1f, PilloController.GetSensor(PilloID.Pillo2) + (-Input.GetAxis("Horizontal2") + 1f) / 2f);

        if(_sensitivityPilloOne >= 0.1f)
		{
			_pillowOneState = PillowState.PRESSED;
		}
		else
		{
			_pillowOneState = PillowState.RELEASED;
		}
		if(_sensitivityPilloTwo >= 0.1f)
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
			_currentSize.x += 2.8f * Time.deltaTime * _sensitivityPilloOne;
			_currentSize.y -= 0.2f * Time.deltaTime;
		}
		else if (_pillowOneState == PillowState.RELEASED)
		{
			_currentSize.x -= 0.3f * Time.deltaTime;
			timerX += Time.deltaTime;
			if (timerX > 0f)
			{
				_currentSize.x = Mathf.Lerp(_currentSize.x, 1, 0.02f);
			}
		}
		if (_pillowTwoState == PillowState.PRESSED)
		{
			timerY = 0;
            _currentSize.y += 2.8f * Time.deltaTime * _sensitivityPilloTwo;
            _currentSize.x -= 0.2f * Time.deltaTime;
		}
		else if (_pillowTwoState == PillowState.RELEASED)
		{
			_currentSize.y -= 0.3f * Time.deltaTime;
			timerY += Time.deltaTime;
			if (timerY > 0)
			{
				_currentSize.y = Mathf.Lerp(_currentSize.y, 1, 0.02f);
			}
		}
		
		PlayerBody.transform.localScale = _currentSize;
		if (_currentSize.x < _currentSize.y)
		{
			PlayerFace.transform.localScale = new Vector3(_currentSize.x, _currentSize.x, 1f);
		}
		else
		{
			PlayerFace.transform.localScale = new Vector3(_currentSize.y, _currentSize.y, 1f);
		}
        
    }

	

	private void UpdateTexture(string textureName)
	{
		Sprite sprite = Resources.Load (textureName, typeof(Sprite)) as Sprite;
		this.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	public void UpdateFaceTexture(string textureName)
	{
		Sprite sprite = Resources.Load (textureName, typeof(Sprite)) as Sprite;
		SpriteRenderer renderer = GameObject.FindGameObjectWithTag ("FaceObject").GetComponent<SpriteRenderer> ();
		renderer.sprite = sprite;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
	}
}
