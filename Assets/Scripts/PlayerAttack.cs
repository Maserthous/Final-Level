using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject enemyDeath;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boundary" || other.tag == "Hazard" || other.tag == "Platform")
        {
            return;
        }

        if (other.tag == "Enemy")
        {
            Instantiate(enemyDeath, other.transform.position, other.transform.rotation);
        }


        Destroy(other.gameObject);
    }

}

