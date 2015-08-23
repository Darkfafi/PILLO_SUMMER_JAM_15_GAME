using UnityEngine;
using System.Collections;

public class PatternSwitcher : MonoBehaviour {

	public GameObject patternBody1;
	//public GameObject patternBody2;
	string _currentPatternName; 

	// Use this for initialization
	void Start () {
		SwitchPattern("pattern1");
	}
	
	// Update is called once per frame
	void Update () {
		ShowPattern (_currentPatternName,(int)(patternBody1.GetComponent<SpriteRenderer>().bounds.size.x * 100f),(int)(patternBody1.GetComponent<SpriteRenderer>().bounds.size.y * 100));
		//ShowPattern (_currentPatternName,(int)(patternBody2.GetComponent<SpriteRenderer>().bounds.size.x * 100f),(int)(patternBody2.GetComponent<SpriteRenderer>().bounds.size.y * 100));
	}

 	void ShowPattern(string nameTexture,int widthCut,int heightCut){
		Texture2D fullTexture = Resources.Load ("Patterns/" + nameTexture) as Texture2D;
		Sprite sprt = Sprite.Create(fullTexture,new Rect(fullTexture.width / 2 - widthCut / 2,fullTexture.height / 2 - heightCut / 2,widthCut,heightCut),new Vector2(0.5f,0.5f));
		
		gameObject.GetComponent<SpriteRenderer> ().sprite = sprt;
	}

	public void SwitchPattern(string nameTexture){
		_currentPatternName = nameTexture;
	}
}
