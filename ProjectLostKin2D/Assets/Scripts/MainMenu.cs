using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public GameObject optionsUI;
    public GameObject mainUI;
    public GameObject gameBG;

    public void Play()
    {
<<<<<<< HEAD
        SceneManager.LoadScene("Lv1");
=======
        SceneManager.LoadScene("Lvl1_Proto");
>>>>>>> parent of 240d573 (Revert "Merge branch 'master' into nca35")
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        optionsUI.transform.position = new Vector2(optionsUI.transform.position.x, optionsUI.transform.position.y + 2f);
        gameBG.transform.position = new Vector2(gameBG.transform.position.x, optionsUI.transform.position.y + 10.8f);
        //= Vector2.MoveTowards(optionsUI.transform.position, new Vector2(optionsUI.position, 8f), 1f * Time.deltaTime);
    }
}
