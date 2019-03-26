using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashFade : MonoBehaviour
{
    public Image splashImage;

    public string loadLevel;

    void Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadLevel);
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    splashImage.canvasRenderer.SetAlpha(0.0f);
    //    print("Tesst");
    //    FadeIn();
    //    startInit();
    //}

    void  startInit()
    {
        print("Tesst");
          new WaitForSeconds(2.5f);
        FadeOut();
          new WaitForSeconds(2.5f);
        SceneManager.LoadScene(loadLevel);
    }

    private void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }

    private void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
