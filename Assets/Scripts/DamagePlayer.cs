using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {

    public int damage;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameController.game.Damage(damage);
        }
    }
}
