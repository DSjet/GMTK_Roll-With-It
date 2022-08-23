using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    int randNumber;
    int nextBuildIndex;
    public Roulette roulette;

    public void StartGame()
    {
        randNumber = Random.Range(0, 6);
        nextBuildIndex = randNumber;
        GameObject.FindObjectOfType<SavedInfo>().ResetSaves();
        ChangeScene();
    }

    public void ChangeScene()
    {
        roulette.ForceRoulette();
    }
}
