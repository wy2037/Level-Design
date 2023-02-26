using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Player player;
    public float force;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            player.canMove = false;
            //Invoke("CanMoveAgain", bounceTime);
            if (player.isGrounded) {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, player.jumpForce/3f));
            } else {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, player.jumpForce));
            }
        }
    }
}
