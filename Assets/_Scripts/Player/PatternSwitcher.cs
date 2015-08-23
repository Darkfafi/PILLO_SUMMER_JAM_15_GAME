using UnityEngine;
using System.Collections;

public class PatternSwitcher : MonoBehaviour {

	public GameObject patternBody;
	public GameObject fadePattern;
	string _currentPatternName;
	string _prePatternName;

	// Use this for initialization
	void Start () {
		//_patternBody = GameObject.Find ("PatternPlayer");
		//(int)(transform.localScale.x / GetComponent<SpriteRenderer>().bounds.size.x),(int)(transform.localScale.y / GetComponent<SpriteRenderer>().bounds.size.y)
		SwitchPattern("pattern2");
		fadePattern.GetComponent<FadeInOut> ().OnFadeEnd += FadeEnd;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<SpriteRenderer> ().sprite = GivePattern (_currentPatternName,(int)(patternBody.GetComponent<SpriteRenderer>().bounds.size.x * 87),(int)(patternBody.GetComponent<SpriteRenderer>().bounds.size.y * 88));
		if (_prePatternName != null) {
			fadePattern.GetComponent<SpriteRenderer> ().sprite = GivePattern (_prePatternName,(int)(patternBody.GetComponent<SpriteRenderer>().bounds.size.x * 87),(int)(patternBody.GetComponent<SpriteRenderer>().bounds.size.y * 88));
		}
	}

 	Sprite GivePattern(string nameTexture,int widthCut,int heightCut){
		Texture2D fullTexture = Resources.Load ("Patterns/" + nameTexture) as Texture2D;

		Sprite sprt = Sprite.Create(fullTexture,new Rect(fullTexture.width / 2 - widthCut / 2,fullTexture.height / 2 - heightCut / 2,widthCut,heightCut),new Vector2(0.5f,0.5f));
		return sprt; 
	}

	public void SwitchPattern(string nameTexture){
		if (nameTexture != _currentPatternName) {
			fadePattern.GetComponent<FadeInOut> ().SetAlpha (1);
			fadePattern.GetComponent<FadeInOut> ().Fade (0,0.015f);
			_prePatternName = _currentPatternName;
		}
		_currentPatternName = nameTexture;
	}

	void FadeEnd(float value){
		_prePatternName = null;
	}
}
