using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static int scene = 0;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            scene = 0;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            scene = 1;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            scene = 2;
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            scene = 3;
        }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            scene = 4;
        }
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            scene = 0;
        }
    }
    public void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            scene++;
        }
    }

    public void NextLevel ()
    {
        if (scene == 1)
        {
            SceneManager.LoadScene(2);
            Debug.Log("scene is 1");
        }
        else if (scene == 2)
        {
            SceneManager.LoadScene(3);
            Debug.Log("scene is 2");
        }
        else if (scene == 3)
        {
            SceneManager.LoadScene(4);
            Debug.Log("scene is 3");
        }
        else if (scene == 4)
        {
            SceneManager.LoadScene(5);
            Debug.Log("scene is 4");
        }
        else
        {
            Debug.Log("Uh oh");
            Debug.Log(scene);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

