using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int randNumber;
    int nextBuildIndex;

    public void StartGame()
    {
        randNumber = Random.Range(0, 6);
        nextBuildIndex = randNumber;
        ChangeScene();
        GameObject.FindObjectOfType<SavedInfo>().ResetSaves();
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(nextBuildIndex);
    }
}
