using UnityEngine;
using System.Collections;

public class PatternSwitcher : MonoBehaviour {

	public GameObject patternBody;
	string _currentPatternName; 

	// Use this for initialization
	void Start () {
		//_patternBody = GameObject.Find ("PatternPlayer");
		//(int)(transform.localScale.x / GetComponent<SpriteRenderer>().bounds.size.x),(int)(transform.localScale.y / GetComponent<SpriteRenderer>().bounds.size.y)
		SwitchPattern("pattern2");

	}
	
	// Update is called once per frame
	void Update () {
		ShowPattern (_currentPatternName,(int)(patternBody.GetComponent<SpriteRenderer>().bounds.size.x * 100f),(int)(patternBody.GetComponent<SpriteRenderer>().bounds.size.y * 100));
	}

 	void ShowPattern(string nameTexture,int widthCut,int heightCut){
		Texture2D fullTexture = Resources.Load ("Patterns/" + nameTexture) as Texture2D;
		//fullTexture.Resize(256,512);
		Sprite sprt = Sprite.Create(fullTexture,new Rect(fullTexture.width / 2 - widthCut / 2,fullTexture.height / 2 - heightCut / 2,widthCut,heightCut),new Vector2(0.5f,0.5f));

		gameObject.GetComponent<SpriteRenderer> ().sprite = sprt;
	}
	public void SwitchPattern(string nameTexture){
		_currentPatternName = nameTexture;
	}
}
