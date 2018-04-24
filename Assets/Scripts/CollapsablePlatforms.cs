using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsablePlatforms : MonoBehaviour {

    
    public float collapseTime;
    public float animationSpeed;


    
    private Animator anim;
    private float time;

	// Use this for initialization
	void Start () {
        anim = this.GetComponent<Animator>();
        animationStop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag ==("Player"))
        {
            anim.speed = animationSpeed;
            Invoke("animationStop", collapseTime - .0000001f);
            Invoke("disable", collapseTime);    

            
        }
    }

    void disable()
    {
        this.gameObject.SetActive(false);
    }

    void animationStop()
    {
        anim.speed = 0;
    }
}
