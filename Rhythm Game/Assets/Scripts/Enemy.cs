using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool movingRight;
    public Vector3 target;
    public float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = gameObject.transform.position;
        target.x = target.x * -1.0f;
        moveSpeed = moveSpeed/50.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
        if(transform.position == target)
        {
            Destroy(gameObject);
        }
    }
}
