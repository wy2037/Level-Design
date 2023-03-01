using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SynchronizerData;

public class Player : MonoBehaviour
{
    float horizontal, vertical, direction, beat;
    public float speed, jumpForce, rotationSpeed;
    bool canRotate = true;
    public bool canMove = true;
    public LayerMask groundLayer;

    public Rigidbody2D rb;
    public Transform sprite;
    public GameObject groundCheck;
    public float groundCheckRadius, maxBeat;
    public bool isGrounded = false;
    Vector3 Rotation;

    BeatObserver obs;
    float grooveCounter = 0;
    bool hasGrooved = false;
    bool stopDec = false;

    public GameObject shieldSprite;
    public bool shielded = false;

    void Start()
    {
        shieldSprite.SetActive(false);
        obs = GetComponent<BeatObserver>();
        beat = maxBeat;
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
        if (canMove) {
            horizontal = Input.GetAxisRaw("Horizontal") * speed;
            rb.velocity = new Vector2(horizontal, rb.velocity.y);
        }

        if (isGrounded)
        {
            hasGrooved = false;
            Rotation = sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z/90) * 90;
            sprite.rotation = Quaternion.Euler(Rotation);
            if(shielded)
            {
                shieldSprite.transform.rotation = Quaternion.Euler(Rotation);
            }
            canMove = true;

            if (Input.GetKeyDown("space"))
            {
                if (beat <= 0)
                {
                    beat = maxBeat;
                }
                rb.AddForce(new Vector2(0, jumpForce));
                if (rb.velocity.x > 0)
                {
                    direction = 1;
                }
                else if (rb.velocity.x < 0)
                {
                    direction = 0;
                }
                else
                {
                    direction = Random.Range(0, 2);
                }
            }
        } else {
            if (direction == 1f) {
                sprite.Rotate(Vector3.back * rotationSpeed);
                if (shielded)
                {
                    shieldSprite.transform.Rotate(Vector3.back * rotationSpeed);
                }
            } else {
                sprite.Rotate(Vector3.back * rotationSpeed * -1);
                if (shielded)
                {
                    shieldSprite.transform.Rotate(Vector3.back * rotationSpeed * -1);
                }
            }
        }
        if ((obs.beatMask) == BeatType.OnBeat && !isGrounded && !hasGrooved)
        {
            if (grooveCounter < 4)
            {
                grooveCounter++;
                hasGrooved = true;
            }
            if (grooveCounter == 4)
            {
                shielded = true;
                shieldSprite.SetActive(true);
            } else
            {
                shielded = false;
                shieldSprite.SetActive(false);
            }
        }
       // if ((obs.beatMask == BeatType.None) & !isGrounded)
       // {
       //     if (!stopDec)
       //     {
       //         Debug.Log("Test");
       //     }
       // }
        if (beat > 0) {
            beat -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            if (shielded)
            {
                Debug.Log("Hit shield");
                grooveCounter = 0;
            }
        }
    }
}
