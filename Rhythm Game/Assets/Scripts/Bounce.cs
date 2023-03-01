using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Player player;
    public float force, fadeSpeed;
    public SpriteRenderer sprite;
    float fade;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            player.canMove = false;
            sprite.color = new Color(1, 1, 1, 1);
            //Invoke("CanMoveAgain", bounceTime);
            if (player.isGrounded) {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, player.jumpForce/3f));
            } else {
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(force, player.jumpForce));
            }
        }
    }

    void Update() {
        float alpha = sprite.color.a;
        if (sprite.color.a > 0) {
            alpha -= Time.deltaTime * fadeSpeed/255;
            sprite.color = new Color(1, 1, 1, alpha);
        }
    }
}
