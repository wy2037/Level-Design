using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHandler : MonoBehaviour
{
    public List<GameObject> waves = new List<GameObject>();
    // Start is called before the first frame update
    public int index = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PublicVars.beatCount == 1)
        {
            index = 0;
            waves[0].SetActive(true);
        }
        if(PublicVars.beatCount == 16)
        {
            index = 1;
            waves[1].SetActive(true);
            index++;
        }
        if(PublicVars.beatCount == 32)
        {
            waves[2].SetActive(true);
        }
        if (PublicVars.beatCount == 48)
        {
            waves[3].SetActive(true);
        }


    }
}
