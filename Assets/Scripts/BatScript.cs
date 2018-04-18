using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour {

    public float speed;
    public float minDistance;
    public float attackMult;
    public float attackDelay;
    public bool faceLeft;
    public bool attacks;


    private Rigidbody2D rBody;
    private Transform target;
    private float distance;
    private Animator anim;
    private bool isAttacking;
    private float timeSinceAttack;
    

    // Use this for initialization
    void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        isAttacking = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (isAttacking)
        {
            timeSinceAttack += Time.deltaTime;
        }

        if (timeSinceAttack > attackDelay)
        {
            isAttacking = false;
            timeSinceAttack = 0;
        }

    }
    void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector2.Distance(this.transform.position, target.position);

        if (attacks)
        {
            if (distance > minDistance && !isAttacking)
            {
                anim.SetBool("attack", false);
                rBody.velocity = (target.position - this.transform.position) * speed;
            }
            else if (distance <= minDistance && !isAttacking)
            {
                anim.SetBool("attack", true);
                rBody.velocity = (target.position - this.transform.position) * speed * attackMult;
                isAttacking = true;
            }
        }
        else
        {
            if (distance > minDistance && !isAttacking)
            {
                anim.SetBool("attack", false);
                rBody.velocity = (target.position - this.transform.position) * speed;
            }
        }

        if (rBody.velocity.x < 0 && !faceLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            faceLeft = true;
        }
        else if (rBody.velocity.x > 0 && faceLeft)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            faceLeft = false;
        }



    }
}
