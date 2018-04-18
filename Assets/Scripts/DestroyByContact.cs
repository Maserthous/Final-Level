using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

 
    public GameObject playerDeath;

    

    // Use this for initialization
    void Start()
    {
       
    }
        void OnTriggerEnter2D(Collider2D other)
        {
        if(other.tag == "Boundary"||other.tag == "Hazard" || other.tag == "Platform")
        {
            return;
        }

        if(other.tag == "Player")
        {
            Instantiate(playerDeath, other.transform.position, other.transform.rotation);
        }


        Destroy(other.gameObject);
            }
	
}
