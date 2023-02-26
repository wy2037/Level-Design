using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontal, vertical, direction;
    public float speed, jumpForce, rotationSpeed;
    bool canRotate = true;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public Transform sprite;
    public GameObject groundCheck;
    public float groundCheckRadius;
    public bool isGrounded = false;
    Vector3 Rotation;



    void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
        //groundCheck.transform.position = gameObject.transform.position + offset;

        if (isGrounded)
        {
            Rotation = sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z/90) * 90;
            sprite.rotation = Quaternion.Euler(Rotation);
            if (Input.GetKeyDown("space")) {
                rb.AddForce(new Vector2(0, jumpForce));
                if (rb.velocity.x > 0) {
                    direction = 1;
                } else if (rb.velocity.x < 0) {
                    direction = 0;
                } else {
                    direction = Random.Range(0, 2);
                }
            }
        } else {
            if (direction == 1f) {
                sprite.Rotate(Vector3.back * rotationSpeed);
            } else {
                sprite.Rotate(Vector3.back * rotationSpeed * -1);
            }
        }
    }
}
