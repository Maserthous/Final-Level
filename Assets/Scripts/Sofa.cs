using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
