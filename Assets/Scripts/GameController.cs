using System;
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
    public float iTime;

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
