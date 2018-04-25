using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController game;

    private bool gameOver;

    [Header("GUI")]
    public Text textHealth;
    public Text textGameOver;
    public Text textRestart;
    public Text textWinner;

    [Header("Player")]
    public GameObject player;
    public int playerHealth;
    public GameObject playerDeath;
    public float iTime;
    public AudioSource keyPickup;

    private bool key;
    private PlayerController pc;
    private float iTimePassed;
    private bool invincible;
    private AudioSource hitSound;

    [Header("Collapsible Platforms")]
    public float respawnTime;
    public GameObject[] platforms;
    
    

    void Start () {
        game = this;
        pc = player.GetComponent<PlayerController>();
        StartCoroutine(platRespawn());
        hitSound = this.GetComponent<AudioSource>();
        UpdateHealth();
      

    }
	
	
	void Update () {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        keyPickup.Play();
        key = newKey;
        pc.Key(key);
    }

    public bool GetKey()
    {
        return key;
    }

    public void Damage(int damage)
    {
        if (!invincible)
        {

            playerHealth -= damage;
            UpdateHealth();
            hitSound.Play();
            if (playerHealth <= 0)
            {
                Death();
            }
            StartCoroutine(Invincible());
        }
    }

    public void Death()
    {
        Instantiate(playerDeath, player.transform.position, player.transform.rotation);
        Destroy(player);
        gameOver = true;
        textGameOver.gameObject.SetActive(true);
        textRestart.gameObject.SetActive(true);
    }
    
    public void Win()
    {
        gameOver = true;
        textWinner.gameObject.SetActive(true);
        textRestart.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    IEnumerator Invincible()
    {
        invincible = true;
        yield return new WaitForSeconds(iTime);
        invincible = false;
    }

    IEnumerator platRespawn()
    {
        
        while (true)
        {
            for (int i = 0; i<platforms.Length;i++)
            {
                if (!platforms[i].activeSelf)
                {
                    yield return new WaitForSeconds(respawnTime);
                    
                    platforms[i].SetActive(true);
                }
                
            }
            yield return new WaitForFixedUpdate();
            
        }
    }
}
