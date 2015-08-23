using UnityEngine;
using UnityEngine.UI;
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

    bool shakeEnable = false;

    float speed = 0.1f;
	
    // Use this for initialization
    void Start () {

        currentLevel = 1;
        minLevel = 1;
        // geef de nodes de tag "node"
        LevelNodes = GameObject.FindGameObjectsWithTag("Node");

        maxLevel = LevelNodes.Length;

        PlayerProgressSaveAndLoad.SetLevel(4);

    }
	
	// Update is called once per frame
	void Update () {
		
		foreach (GameObject node in LevelNodes)
		{
            if (PlayerProgressSaveAndLoad.GetLevel() >= node.GetComponent<NodeScript>().LevelNumber)
            {
                node.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                node.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }

            if (node.GetComponent<NodeScript>().LevelNumber == currentLevel)
            {
                if (shakeEnable)
                {
                    node.GetComponent<ShakeNo>().DoShake();
                    shakeEnable = false;
                }
                
                if (PlayerProgressSaveAndLoad.GetLevel() < currentLevel)
                {
                    print("you have not unlocked "+currentLevel);
                    currentLevel--;
                    shakeEnable = true;
                    
                    
                }
                CurrentLevelNode = node;
                node.GetComponent<BreatheScript>().enabled = true;
                
            }
            else
            {
                node.GetComponent<BreatheScript>().enabled = false;
                
            }
            if (PlayerProgressSaveAndLoad.GetLevel() < currentLevel)
            {
                
            }
            /*if (node.GetComponent<NodeScript>().LevelNumber == currentLevel + 1 && currentLevel < maxLevel)
           {
               NextLevelNode = node;
           }
           if (node.GetComponent<NodeScript>().LevelNumber == currentLevel - 1 && currentLevel > minLevel)
           {
               PreviousLevelNode = node;

           }*/
        }

        transform.position = new Vector3(Mathf.Lerp(transform.position.x, CurrentLevelNode.transform.position.x, speed), 
			Mathf.Lerp(transform.position.y, CurrentLevelNode.transform.position.y, speed), transform.position.z);

        //when pillo 1 shaked
        if (Input.GetKeyDown(KeyCode.A))
        {
            PreviousNode();
            Debug.Log("previousnodeinvoked");
        }
		
		//when pillo 2 shaked
        if (Input.GetKeyDown(KeyCode.D))
        {
            NextNode();
            Debug.Log("nextnodeinvoked");
        }
		
		//when both pillo's pressed
		if (Input.GetKeyDown(KeyCode.W))
        {
            SelectCurrentNode();
            Debug.Log("selected");
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
	
	void SelectCurrentNode()
	{
        Application.LoadLevel("Level"+currentLevel);
    }
}
