using UnityEngine;
using System.Collections;

public class RangeChecker : MonoBehaviour {

	private float baseScaleX = 0;
	private float baseScaleY = 0;
	public float scalerRange;
	private PlayerController target;
	// Use this for initialization
	void Start () {
		target = (PlayerController)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController");
		scalerRange = 5f;
		transform.localScale = new Vector3 (20, 20, 0);
		baseScaleX = transform.localScale.x;
		baseScaleY = transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (InScaleRange ()) {
			Application.LoadLevel("RoadMap");
		}
	}

	private bool InScaleRange()
	{
		GameObject _playerBody = target.GetComponent<PlayerController>().PlayerBody;
		
		Vector3 minScaleRange = new Vector3 (baseScaleX - scalerRange, baseScaleY - scalerRange, 1);
		Vector3 maxScaleRange = new Vector3 (baseScaleX + scalerRange, baseScaleY + scalerRange, 1);
		//print (minScaleRange + "  t" + maxScaleRange + " p " + _playerBody.transform.localScale);
		//print (minScaleRange + "max " + maxScaleRange + " player" + _playerBody.transform.localScale);
		if (_playerBody.transform.localScale.x > minScaleRange.x && _playerBody.transform.localScale.x < maxScaleRange.x &&
		    _playerBody.transform.localScale.y > minScaleRange.y && _playerBody.transform.localScale.y < maxScaleRange.y) {
			return true;
		}
		return false;
	}
}
