using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [Header("GUI")]
    public GameObject textHealth;

    [Header("Player")]
    public GameObject player;
    public int playerHealth;
	
    [Header("Collapsible Platforms")]
    public float respawnTime;
    public GameObject[] platforms;
    



    private float disabledTime;
    void Start () {
		
	}
	
	
	void Update () {

        for (int i = 0; i < platforms.Length; i++)
        {
            if (!platforms[i].activeSelf)
            {

                disabledTime += Time.deltaTime;
                Debug.Log(disabledTime);
                if (disabledTime >= respawnTime)
                {
                    
                    platforms[i].SetActive(true);
                    disabledTime = 0;
                }
            }
        }
    }
}
