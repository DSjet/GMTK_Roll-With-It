using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseContinue : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


    }

    public void PauseGame()
    {
        if (isPaused == false)
        {
            //FindObjectOfType<SAudioManager>().Play("Button");
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(true);
        }
    }

    public void MainMenu()
    {
        ResumeGame();
        ResetGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void ResetGame()
    {
        //skills
        PlayerPrefs.SetInt("a1", 0);
        PlayerPrefs.SetInt("a2", 0);
        PlayerPrefs.SetInt("a3", 0);
        PlayerPrefs.SetInt("a4", 0);
        PlayerPrefs.SetInt("a5", 0);
        PlayerPrefs.SetInt("a6", 0);

        //game progress save
        SavedInfo saves = GameObject.FindObjectOfType<SavedInfo>();
        saves.playerHealth = 6;
        for (int i = 0; i < saves.completed.Length; i++)
        {
            saves.completed[i] = false;
        }
        saves.levelsCompleted = 0;

    }

    public void ResumeGame()
    {
        if(isPaused == true)
        {
            FindObjectOfType<SAudioManager>().Play("Button");
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(false);
        }

    }
}
