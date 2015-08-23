using UnityEngine;
using System.Collections;

public class WaveType {

	public const string NORMAL_SHAPE = "NormalShape";
	public const string BLACK_SHAPE = "BlackShape";

	private string _typeWaveType;
	private float _speedWaveType;

	public WaveType(string type, float speed){
		_typeWaveType = type;
		_speedWaveType= speed;
	}

	public string type{
		get{return _typeWaveType;}
	}
	public float speed{
		get{return _speedWaveType;}
	}
}
