using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public WorldChange worldChange;
    public UnitHealth _playerHealth;

    public int enemiesRemaining = 1;

    private void Awake()
    {
        _playerHealth = new UnitHealth(GameObject.FindObjectOfType<SavedInfo>().playerHealth, 6);

        worldChange = FindObjectOfType<WorldChange>();
        if (gameManager != null && gameManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameManager = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //testing
            enemiesRemaining--;
            Debug.Log("enemies left: " + enemiesRemaining);
            SavedInfo.enemiesKilled++;
        }
        if (enemiesRemaining <= 0)
        {
            Win();
        }
    }

    public void Win()
    {
        Debug.Log("Won World #" + worldChange.currentBuildIndex);
        if (GameObject.FindObjectOfType<SavedInfo>().completed[worldChange.currentBuildIndex] == false)
        {
            GameObject.FindObjectOfType<SavedInfo>().levelsCompleted++;
            int world = worldChange.currentBuildIndex;
            switch (world) {
                case 0:
                    PlayerPrefs.SetInt("a1", 1);
                    break;
                case 1:
                    PlayerPrefs.SetInt("a2", 1);
                    break;
                case 2:
                    PlayerPrefs.SetInt("a3", 1);
                    break;
                case 3:
                    PlayerPrefs.SetInt("a4", 1);
                    break;
                case 4:
                    PlayerPrefs.SetInt("a5", 1);
                    break;
                case 5:
                    PlayerPrefs.SetInt("a6", 1);
                    break;
            }
        }
        GameObject.FindObjectOfType<SavedInfo>().completed[worldChange.currentBuildIndex] = true;
        GameObject.FindObjectOfType<SavedInfo>().playerHealth = _playerHealth.GetHealth();
        worldChange.ChangeScene();
    }
    public void Lose()
    {

    }
}