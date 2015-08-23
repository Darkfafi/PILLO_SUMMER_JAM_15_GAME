using UnityEngine;
using System.Collections;

public class PlayerProgressSaveAndLoad : MonoBehaviour {
	
	public static void SetLevel(int l)
	{
        PlayerPrefs.SetInt("level", l);
    }
	
	public static int GetLevel()
	{
		if (!PlayerPrefs.HasKey("level"))
        {
			PlayerPrefs.SetInt("level", 1);
		}
        return PlayerPrefs.GetInt("level");
    }
}
