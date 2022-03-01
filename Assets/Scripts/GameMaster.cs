using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public float playerPoints;
    public float maxLevelPoints;
    public float playerLives = 3;
    public Text scoreCounter;
    public Text livesCounter;

    // Start is called before the first frame update
    void Start()
    {
        scoreCounter.text = "Score: " + playerPoints;
        livesCounter.text = "Lives: " + playerLives;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounter.text = "Score: " + playerPoints * 10;
        livesCounter.text = "Lives: " + playerLives;
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (playerPoints >= maxLevelPoints && SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene("FinalWin");
        } else if (playerPoints >= maxLevelPoints)
        {
            SceneManager.LoadScene("WinScene");
        }  

        if (Input.GetKeyDown(KeyCode.N))
        {
            playerPoints = maxLevelPoints;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("LoseScene");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("FinalWin");
        }
    }

}
