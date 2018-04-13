using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask isGround;

    private Rigidbody2D rBody;
    private Animator anim;

    private float move;
    private bool grounded = true;
    private float groundRadius;
    
    private bool faceRight = true;
	
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
	}

    private void Update()
    {
        if (grounded && Input.GetButtonDown("Jump"))
        {
            grounded = false;
            anim.SetBool("ground", false);
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        rBody.velocity = new Vector2(move *moveSpeed, rBody.velocity.y);

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, isGround);
        anim.SetBool("ground", grounded);


        anim.SetFloat("move", Mathf.Abs(move));
        if (move < 0 && faceRight)
            Flip();
        else if (move > 0 && !faceRight)
            Flip();


    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
