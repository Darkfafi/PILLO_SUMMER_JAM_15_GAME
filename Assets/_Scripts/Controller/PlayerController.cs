using UnityEngine;
using System.Collections;
using Pillo;

public class PlayerController : MonoBehaviour {

	#region variable/properties
	public Vector3 _minSize;
	public Vector3 _maxSize;

	public GameObject PlayerBody;
	public GameObject PlayerFace;
	public PatternSwitcher PlayerPattern;
	private Animator anim;
	#endregion

	// Use this for initialization
	void Start () {
		PlayerFace = GameObject.FindGameObjectWithTag ("FaceObject");
		anim = GetComponentInChildren<Animator> ();
		PilloController.ConfigureSensorRange(0x50, 0x6f);
		_minSize = new Vector3 (10, 10, 0);
		_maxSize = new Vector3 (30, 30, 0);
		this.transform.localScale = new Vector3 (1, 1, 0);
		PlayerFace.transform.localScale = new Vector3 (10, 10, 0);
	}

	// Update is called once per frame
	void Update () {
		UpdateCurrentSize ();
	}

	private void UpdateCurrentSize()
	{
		//PlayerBody.transform.localScale = new Vector3(_currentSize.x * 10, _currentSize.y * 10,1f);
//		Debug.Log (Mathf.RoundToInt((PilloController.GetSensor (PilloID.Pillo1) * 10)) * 0.1f);
		PlayerBody.transform.localScale = new Vector3(_minSize.x + Mathf.RoundToInt ((PilloController.GetSensor (PilloID.Pillo1)) * 10) * 0.1f * (_maxSize.x - _minSize.x) ,
		                                              _minSize.y + Mathf.RoundToInt ((PilloController.GetSensor (PilloID.Pillo2)) * 10) * 0.1f * (_maxSize.y - _minSize.y) ,1f);
		anim.SetFloat ("X", _minSize.x + Mathf.RoundToInt ((PilloController.GetSensor (PilloID.Pillo1)) * 10) * 0.1f * (_maxSize.x - _minSize.x)-10);
		anim.SetFloat ("Y", _minSize.y + Mathf.RoundToInt ((PilloController.GetSensor (PilloID.Pillo2)) * 10) * 0.1f * (_maxSize.y - _minSize.y)-10);
	}

	private void UpdateTexture(string textureName)
	{
		Sprite sprite = Resources.Load (textureName, typeof(Sprite)) as Sprite;
		this.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	public void UpdateFaceTexture(string textureName)
	{
		Sprite sprite = Resources.Load ("Art/"+textureName, typeof(Sprite)) as Sprite;
		SpriteRenderer renderer = GameObject.FindGameObjectWithTag ("FaceObject").GetComponent<SpriteRenderer> ();
		renderer.sprite = sprite;
	}
}
