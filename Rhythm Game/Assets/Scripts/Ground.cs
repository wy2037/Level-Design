using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SynchronizerData;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    private BeatObserver obs;
    private SpriteRenderer spr;
    private Color baseCol;
    bool beatHit = false;
    public float beatCount = 0;
    void Start()
    {
        obs = GetComponent<BeatObserver>();
        spr = GetComponent<SpriteRenderer>();
        baseCol = spr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if ((obs.beatMask & BeatType.OnBeat) == BeatType.OnBeat && beatHit == false)
        {
           StartCoroutine(colorPulse());
            beatCount++;
            PublicVars.beatCount = beatCount;
        }
        if (beatHit)
        {

            spr.color = new Color(spr.color.r - .009f, spr.color.g - .009f, spr.color.b - .009f);
        }
    }

    IEnumerator colorPulse()
    {
        beatHit = true;
        spr.color = new Color(1, 1, 1);
        yield return new WaitForSeconds(0.2f);
        //spr.color = baseCol;
        beatHit = false;
    }
}
