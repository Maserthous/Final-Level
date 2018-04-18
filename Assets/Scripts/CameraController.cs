using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Vector3 offset;
    public bool on;

    private void Start(){
        
    }

    void LateUpdate () {
        if(on)
            transform.position = player.transform.position + offset;
	}
}
