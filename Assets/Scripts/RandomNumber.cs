using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomNumber : MonoBehaviour
{
    float fadeTime = 2.0f;
    float alpha = 0;
    bool fadeIn = false;
    bool fadeOut = false;
    float increment;
    // Start is called before the first frame update
    void Start()
    {
        increment = fadeTime / 255;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeIn == true)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, alpha);
            alpha += increment;
            fadeTime -= Time.deltaTime;

            if(fadeTime <= 0)
            {
                fadeIn = false;
                fadeTime = 2.0f;
                Invoke("FadeOut", 2f);
                
            }
        }

        if (fadeOut == true)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, alpha);
            alpha -= increment;
            fadeTime -= Time.deltaTime;

            if (fadeTime <= 0)
            {
                this.gameObject.GetComponent<TextMeshProUGUI>().color = new Color(0, 0, 0, 0);
                fadeOut = false;
                fadeTime = 2.0f;
            }
        }

    }

    public void FadeIn()
    {
        fadeIn = true;
    }

    void FadeOut()
    {
        fadeOut = true;
    }

}
