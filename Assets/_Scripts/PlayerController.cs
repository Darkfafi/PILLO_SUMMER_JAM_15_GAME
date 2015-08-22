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
	private float range;
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
		_sensitivityPilloOne = PilloController.GetSensor (PilloID.Pillo1);
		_sensitivityPilloTwo = PilloController.GetSensor (PilloID.Pillo2);
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
		transform.localScale = _currentSize;
	}

	private bool InScaleRange(GameObject shape)
	{
		Vector3 minScaleRange = new Vector3 (shape.transform.localScale.x - range, shape.transform.localScale.y - range, 0);
		Vector3 maxScaleRange = new Vector3 (shape.transform.localScale.x + range, shape.transform.localScale.y + range, 0);
		print (minScaleRange + "space " + maxScaleRange + "this scale " + this.transform.localScale);
		if (this.transform.localScale.x > minScaleRange.x && this.transform.localScale.x < maxScaleRange.x &&
			this.transform.localScale.y > minScaleRange.y && this.transform.localScale.y < maxScaleRange.y) {
			return true;
		}
		return false;
	}

	public void CheckShape (GameObject shape)
	{
		if (InScaleRange(shape)) {
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
		SpriteRenderer renderer = GameObject.FindGameObjectWithTag ("FaceObject").GetComponent<SpriteRenderer> ();
		renderer.sprite = sprite;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
	}
}
