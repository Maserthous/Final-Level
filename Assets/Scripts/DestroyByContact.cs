using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

 
    public GameObject explosionPlayer;

    

    // Use this for initialization
    void Start()
    {
       
    }
        void OnTriggerEnter2D(Collider2D other)
        {
        if(other.tag == "Boundary"||other.tag == "Hazard")
        {
            return;
        }

        if(other.tag == "Player")
        {
            Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);
        }


        Destroy(other.gameObject);
            }
	
}
