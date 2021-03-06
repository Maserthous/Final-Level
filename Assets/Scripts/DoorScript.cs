﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public AudioSource openSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "Player" || other.tag == "Hitbox") && GameController.game.GetKey())
        {
            this.GetComponent<Animator>().SetBool("open", true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            openSound.Play();
        }
    }
}
