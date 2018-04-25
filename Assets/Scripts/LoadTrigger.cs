using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour {

    public bool load;
    public GameObject loadThis;
    public bool unload;
    public GameObject unloadThis;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (load)
                loadThis.gameObject.SetActive(true);
            if (unload)
                unloadThis.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
