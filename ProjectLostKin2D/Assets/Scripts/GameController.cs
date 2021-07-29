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
        if (menuText.active == true) {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
                menuText.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            menuText.SetActive(true);
            
        }
    }

    



    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        curScene = "MainMenu";
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Demo");
        curScene = "Demo";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
