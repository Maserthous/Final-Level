using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController game;

    [Header("GUI")]
    public GameObject textHealth;

    [Header("Player")]
    public GameObject player;
    public int playerHealth;

    private bool key;
    private PlayerController pc;
	
    [Header("Collapsible Platforms")]
    public float respawnTime;
    public GameObject[] platforms;
    
    private float disabledTime;

    void Start () {
        game = this;
        pc = player.GetComponent<PlayerController>();
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

    public void SetKey(bool newKey)
    {
        key = newKey;
        pc.Key(key);
    }

    public bool GetKey()
    {
        return key;
    }
}
