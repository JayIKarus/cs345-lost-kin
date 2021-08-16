using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public static GameController instance;
    public bool gameOver = false;
    public GameObject menuText;
    string curScene;
    public static bool gamePaused = false;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        curScene = "MainMenu";
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (gameOver == true && Input.GetKeyDown(KeyCode.Backspace))
        {
            QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            if (gamePaused) {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        menuText.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void Pause()
    {
        menuText.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }


    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
        curScene = "StartMenu";
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Lvl1_Proto");
        curScene = "Lvl1_Proto";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
