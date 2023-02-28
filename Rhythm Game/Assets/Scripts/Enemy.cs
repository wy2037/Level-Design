using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SynchronizerData;

public class Enemy : MonoBehaviour
{
    public bool moving = false;
    public Vector3 target;
    public float moveSpeed = 1.0f;
    private BeatObserver obs;
    // Start is called before the first frame update
    void Start()
    {
        obs = GetComponent<BeatObserver>();
        StartCoroutine(waitAdd());
        target = gameObject.transform.position;
        target.x = target.x * -1.0f;
        moveSpeed = moveSpeed/50.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((obs.beatMask & BeatType.OnBeat) == BeatType.OnBeat && moving == false)
        {
            StartCoroutine(moveOnBeat());
        }
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * 2);
        }
        //transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
        if(transform.position == target)
        {
            MusicHandler.m.removeObserver(gameObject);
            Destroy(gameObject);
        }
    }

    IEnumerator moveOnBeat()
    {
        moving = true;
        yield return new WaitForSeconds(0.2f);
        moving = false;

    }

    IEnumerator waitAdd()
    {
        yield return new WaitForSeconds(0.6f);
        MusicHandler.m.addObserver(gameObject);
    }
}
