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
            waves[index].SetActive(true);
            Debug.Log("hit!");
        }
        if(PublicVars.beatCount == 16)
        {
            index = 1;
            waves[index].SetActive(true);
            index++;
        }
        if(PublicVars.beatCount == 32)
        {
            /*
            if (!waves[index].activeSelf)
            {
                waves[index].SetActive(true);
                index++;
            }
            */
        }
        

    }
}
