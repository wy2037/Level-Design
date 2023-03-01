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

    public GameObject shieldSprite;
    public bool shielded = false;
    float baseSpeed;

    public GameObject[] grooveBar;

    void Start()
    {
        obs = GetComponent<BeatObserver>();
        beat = maxBeat;
        rotationSpeed = 10f;
        baseSpeed = speed;
    }

    void Update() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, groundCheckRadius, groundLayer);
        if (canMove) {
            horizontal = Input.GetAxisRaw("Horizontal") * speed;
            rb.velocity = new Vector2(horizontal, rb.velocity.y);
        }

        if (isGrounded)
        {
            Rotation = sprite.rotation.eulerAngles;
            Rotation.z = Mathf.Round(Rotation.z/90) * 90;
            sprite.rotation = Quaternion.Euler(Rotation);
            canMove = true;
            if (shielded)
            {
                shieldSprite.transform.rotation = Quaternion.Euler(Rotation);
            }

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
        if(Input.GetKeyDown("space") && hasGrooved)
        {
            grooveCounter = 0;
        }
        if ((obs.beatMask) == BeatType.OnBeat && !isGrounded && !hasGrooved)
        {
            hasGrooved = true;
            StartCoroutine(grooveTime());
            if (grooveCounter < 4)
            {
                grooveCounter++;
            }
            speed = baseSpeed + (grooveCounter * 2);
            if (grooveCounter == 4)
            {
                shielded = true;
                shieldSprite.SetActive(true);
            }
            else
            {
                shielded = false;
                shieldSprite.SetActive(false);
            }
            Debug.Log(grooveCounter);
        }
        if (grooveCounter == 0)
        {
            speed = baseSpeed;
            grooveBar[0].SetActive(false);
            grooveBar[1].SetActive(false);
            grooveBar[2].SetActive(false);
            grooveBar[3].SetActive(false);
        } else if (grooveCounter == 1)
        {
            grooveBar[0].SetActive(true);
        } else if(grooveCounter == 2)
        {
            grooveBar[0].SetActive(true);
            grooveBar[1].SetActive(true);
        } else if (grooveCounter == 3)
        {
            grooveBar[0].SetActive(true);
            grooveBar[1].SetActive(true);
            grooveBar[2].SetActive(true);
        } else if (grooveCounter == 4)
        {
            grooveBar[0].SetActive(true);
            grooveBar[1].SetActive(true);
            grooveBar[2].SetActive(true);
            grooveBar[3].SetActive(true);
        }
        
        if (beat > 0) {
            beat -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
        }
        if (collision.gameObject.CompareTag("Barrier"))
        {
            canMove = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            canMove = false;
        }
    }

    IEnumerator grooveTime()
    {
        yield return new WaitForSeconds(0.2f);
        hasGrooved = false;
    }
}
