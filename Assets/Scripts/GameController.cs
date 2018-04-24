using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController game;

    [Header("GUI")]
    public Text textHealth;

    [Header("Player")]
    public GameObject player;
    public int playerHealth;
    public GameObject playerDeath;

    private bool key;
    private PlayerController pc;
	
    [Header("Collapsible Platforms")]
    public float respawnTime;
    public GameObject[] platforms;
    
    private float disabledTime;

    void Start () {
        game = this;
        pc = player.GetComponent<PlayerController>();

        UpdateHealth();
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

    public void UpdateHealth()
    {
        textHealth.text = "";
        for (int i = 1; i <= playerHealth; i++)
        {
            textHealth.text += "\u2764";
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

    public void Damage(int damage)
    {
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(playerDeath, player.transform.position, player.transform.rotation);
        Destroy(player);
    }
}
