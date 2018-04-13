using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Movement")]
    public float moveSpeed;

    private float move;
    private bool faceRight;

    [Header("Jumping")]
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask isGround;

    private bool grounded;
    private float groundRadius;

    [Header("Attacking")]
    public GameObject attackHitBox;
    public float attackCooldown;

    private float attackTime = 0.0f;
    private bool attacking;

    private Rigidbody2D rBody;
    private Animator anim;
	
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        faceRight = true;
        attacking = false;
	}

    private void Update()
    {
        if (grounded && Input.GetButton("Jump"))
        {
            grounded = false;
            anim.SetBool("ground", false);
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        attackTime += Time.deltaTime;
        if ((grounded && attackTime >= attackCooldown) && Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("attack", true);
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, isGround);
        anim.SetBool("ground", grounded);
        
        move = Input.GetAxis("Horizontal");

        if (!attacking)
        {
            rBody.velocity = new Vector2(move * moveSpeed, rBody.velocity.y);

            anim.SetFloat("move", Mathf.Abs(move));
            if (move < 0 && faceRight)
                Flip();
            else if (move > 0 && !faceRight)
                Flip();
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void EnableAttacking()
    {
        attacking = true;
    }

    private void DisableAttacking()
    {
        attacking = false;
        anim.SetBool("attack", false);
    }

    public void EnableHitBox()
    {
        attackHitBox.SetActive(true);
    }

    public void DisableHitBox()
    {
        attackHitBox.SetActive(false);
    }
}
