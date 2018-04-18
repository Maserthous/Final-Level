using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinyScript : MonoBehaviour {

    public float speed; // 1 = 2 blocks per second
    public float turnTime; // Seconds bewteen turns
    public float timeSinceTurn; // Time since last turn
    public bool faceRight;
    public int damage;

    private Rigidbody2D rBody;

	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();
        if (faceRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

	void Update () {

        timeSinceTurn += Time.deltaTime;

        if (timeSinceTurn >= turnTime)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            timeSinceTurn = 0;
            faceRight = !faceRight;
        }
    }

    private void FixedUpdate()
    {
        if (faceRight)
            rBody.velocity = new Vector2(1, 0) * speed;
        else
            rBody.velocity = new Vector2(-1, 0) * speed;
    }
}
