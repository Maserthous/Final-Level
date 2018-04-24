using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public float moveSpeedAttack;
    

    private float move;
    private bool faceRight;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpShortMult;
    public float jumpMax;
    public Transform groundCheck;
    public LayerMask isGround;

    private bool grounded;
    private float groundRadius = 0.05f;
    private bool jumping;
    private float holdTime;

    [Header("Combat")]
    public GameObject attackHitBox;
    public float attackCooldown;
    public float invincibleTime;
    public float soundDelay;


    private float attackTime = 0.0f;
    private bool attacking;
    private AudioSource attackSound;

    [Header("Misc")]
    
    private bool key = false;


    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        attackSound = this.GetComponent<AudioSource>();
        faceRight = true;
        attacking = false;
        attackTime = attackCooldown;
    }

    private void Update()
    {
        if (grounded && Input.GetButtonDown("Jump") && !jumping)
        {
            holdTime = 0;
            jumping = true;
        }
        if (jumping)
        {
            holdTime += Time.deltaTime;
            if (holdTime >= jumpMax)
            {
                jumping = false;
                rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else if (Input.GetButtonUp("Jump"))
            {
                jumping = false;
                rBody.AddForce(new Vector2(0, jumpForce * jumpShortMult), ForceMode2D.Impulse);
            }
        }

        attackTime += Time.deltaTime;
        if ((attackTime >= attackCooldown) && Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("attack", true);
            
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, isGround);
        anim.SetBool("ground", grounded);

        if (!attacking)
        {
            move = Input.GetAxis("Horizontal");
            rBody.velocity = new Vector2(move * moveSpeed, rBody.velocity.y);
            
            anim.SetFloat("move", Mathf.Abs(move));
            if (move < 0 && faceRight)
                Flip();
            else if (move > 0 && !faceRight)
                Flip();
        }
        else
        {
            move = Input.GetAxis("Horizontal");
            rBody.velocity = new Vector2(move * moveSpeedAttack, rBody.velocity.y);
        }

       
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void EnableAttacking()
    {
        attacking = true;
        attackSound.PlayDelayed(soundDelay);
    }

    public void DisableAttacking()
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

    public void Key(bool hasKey)
    {
        key = hasKey;
        anim.SetBool("key", hasKey);
        
    }

    public bool FaceRight()
    {
        return faceRight;
    }

  
}
