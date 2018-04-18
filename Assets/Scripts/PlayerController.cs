﻿using System.Collections;
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
    public float jumpDelay;
    public Transform groundCheck;
    public LayerMask isGround;

    private bool grounded;
    private float groundRadius = 0.1f;
    private float jumpReset;

    [Header("Combat")]
    public GameObject attackHitBox;
    public float attackCooldown;
    public float invincibleTime;

    private float attackTime = 0.0f;
    private bool attacking;

    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        faceRight = true;
        attacking = false;
        attackTime = attackCooldown;
    }

    private void Update()
    {
        jumpReset += Time.deltaTime;
        if (grounded && Input.GetButtonDown("Jump") && jumpReset >= jumpDelay)
        {
            grounded = false;
            anim.SetBool("ground", false);
            rBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
}
