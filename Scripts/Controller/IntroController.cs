using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public void doQuit()
    {
        Debug.Log("Quit Application");
        Application.Quit();
    }

    public void doSkip(string scenceName)
    {
        Debug.Log("Skip Intro -> MenuScence");
        SceneManager.LoadScene(scenceName);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

