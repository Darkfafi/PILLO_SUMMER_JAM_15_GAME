using UnityEngine;
using System.Collections;

public class PlayerTransformer : MonoBehaviour {

	public delegate void StringDelegate(string stringValue);
	public event StringDelegate PlayerTransformingInto;

	public const string FORM_DEFAULT = "formDefault";
	public const string FORM_NON = "formNon"; // if still changing into form then the player is no form yet. so as default a wrong answer to the call.

	private string _currentForm;
	/*
	public void TransformInto(string formString){
		string changeTestString = "Change Into ";
		switch (formString) {
		case FormConstants.FORM_ONE:
			changeTestString += "Form 1";
			break;
		case FormConstants.FORM_TWO:
			changeTestString += "Form 2";
			break;
		case FormConstants.FORM_THREE:
			changeTestString += "Form 3";
			break;
		case FORM_DEFAULT:
			changeTestString += "Form default";
			break;
		}

		_currentForm = FORM_NON; // Set variable to form if the aniamtion has been completed.

		if (PlayerTransformingInto != null) {
			PlayerTransformingInto (formString);
		}

		Debug.Log (changeTestString);
	}
*/
	public string currentForm{
		get{return _currentForm;}
		set{_currentForm = value;}
	}
}
