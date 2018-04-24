using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject enemyDeath;
    public float xForce;
    public float yForce;
    public GameObject player;

    private PlayerController pc;
    private bool key;
    private bool faceRight;

    private void Start()
    {
        pc = player.GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            key = GameController.game.GetKey();
            faceRight = pc.FaceRight();
            if (!key)
            {
                Instantiate(enemyDeath, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
            }
            else if (key && faceRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, yForce), ForceMode2D.Impulse);
            }
            else if (key && !faceRight)
            {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xForce, yForce), ForceMode2D.Impulse);
            }
        }
    }

}

