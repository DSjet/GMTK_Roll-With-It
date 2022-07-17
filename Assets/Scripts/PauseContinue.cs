using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseContinue : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;

    private void Start()
    {
        ResumeGame();
    }

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
        SavedInfo saves = GameObject.FindObjectOfType<SavedInfo>();
        saves.ResetSaves();
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
