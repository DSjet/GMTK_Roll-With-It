using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseContinue : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject loseMenu;
    public bool hasLost = false;

    private void Start()
    {
        loseMenu.SetActive(false);
        ResumeGame();
        isPaused = false;
        hasLost = false;

    }

    private void Update()
    {

        if (isPaused && !hasLost)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                ResumeGame();
        }
        else if(!isPaused && !hasLost)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PauseGame();
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
        hasLost = false;
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

    public void Lost()
    {
        Time.timeScale = 0;
        isPaused = true;
        hasLost = true;
        loseMenu.SetActive(true);
    }
}
