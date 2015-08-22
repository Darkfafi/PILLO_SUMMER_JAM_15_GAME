using UnityEngine;
using System.Collections;

public class LevelSelectScript : MonoBehaviour {

    GameObject NextLevelNode;
    GameObject CurrentLevelNode;
    GameObject PreviousLevelNode;
    public GameObject[] LevelNodes;
    public int currentLevel;
    int previousLevel;
    int nextLevel;
    int maxLevel;
    int minLevel;
    // Use this for initialization
    void Start () {

        currentLevel = 1;
        minLevel = 1;
        // geef de nodes de tag "node"
        LevelNodes = GameObject.FindGameObjectsWithTag("Node");

        maxLevel = LevelNodes.Length;

    }
	
	// Update is called once per frame
	void Update () {
		
		foreach (GameObject node in LevelNodes)
		{
            if (node.GetComponent<NodeScript>().LevelNumber == currentLevel)
            {
                CurrentLevelNode = node;
				
            }
			 if (node.GetComponent<NodeScript>().LevelNumber == currentLevel + 1 && currentLevel < maxLevel)
            {
                NextLevelNode = node;
				
            }
			if (node.GetComponent<NodeScript>().LevelNumber == currentLevel - 1 && currentLevel > minLevel)
            {
                PreviousLevelNode = node;
				
            }
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, CurrentLevelNode.transform.position.x, 0.05f), 
			Mathf.Lerp(transform.position.y, CurrentLevelNode.transform.position.y, 0.05f), transform.position.z);

        //getbtn
        if (Input.GetKeyDown(KeyCode.A))
        {
            NextNode();
            Debug.Log("nextnodeinvoked");
        }
    }
	
	void NextNode()
	{
		if (currentLevel < maxLevel)
		{
			currentLevel++;
		}
    }
	
	void PreviousNode()
	{
		if (currentLevel > minLevel)
		{
			currentLevel--;
		}
	}
}
