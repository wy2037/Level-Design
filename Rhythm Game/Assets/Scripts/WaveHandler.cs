using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveHandler : MonoBehaviour
{
    public List<GameObject> waves = new List<GameObject>();
    public List<TextMeshProUGUI> tutorialText = new List<TextMeshProUGUI>();
    // Start is called before the first frame update
    public int index = 0;
    bool text1 = false;
    bool text2 = false;
    bool text3 = false;
    Color fontColor;
    float alpha1 = 0;
    float alpha2 = 0;
    float alpha3 = 0;
    bool textRoll = false;
    void Start()
    {
        fontColor = tutorialText[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        if(PublicVars.beatCount == 1)
        {
            index = 0;
            waves[0].SetActive(true);
        }
        if(PublicVars.beatCount == 2)
        {
            if (!textRoll)
            {
                textRoll = true;
                StartCoroutine(jumpText());
            }
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
        if (PublicVars.beatCount == 40)
        {
            waves[3].SetActive(true);
        } 
        if(PublicVars.beatCount >= 50)
        {
            StartCoroutine(nextStage());
        }
        if (text1)
        {
            alpha1 += 0.03f;
        } 
        if (!text1)
        {
            alpha1 -= 0.03f;
        }
        if (text2)
        {
            alpha2 += 0.03f;
        }
        if (!text2)
        {
            alpha2 -= 0.03f;
        }
        if (text3)
        {
            alpha3 += 0.03f;
        }
        if (!text3)
        {
            alpha3 -= 0.03f;
        }
        tutorialText[0].color = new Color(fontColor.r, fontColor.g, fontColor.b, alpha1);
        tutorialText[1].color = new Color(fontColor.r, fontColor.g, fontColor.b, alpha2);
        tutorialText[2].color = new Color(fontColor.r, fontColor.g, fontColor.b, alpha3);

    }

    IEnumerator nextStage()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Will 2");
    }

    IEnumerator jumpText()
    {
        text1 = true;
        yield return new WaitForSeconds(3.0f);
        text1 = false;
        yield return new WaitForSeconds(3.0f);
        text2 = true;
        alpha2 = 0.0f;
        yield return new WaitForSeconds(3.0f);
        text2 = false;
        yield return new WaitForSeconds(3.0f);
        text3 = true;
        alpha3 = 0.0f;
        yield return new WaitForSeconds(3.0f);
        text3 = false;
        yield return new WaitForSeconds(3.0f);
    }

}
