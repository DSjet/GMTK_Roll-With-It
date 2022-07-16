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
            enemiesRemaining--;
            Debug.Log("enemies left: " + enemiesRemaining);
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
        }
        GameObject.FindObjectOfType<SavedInfo>().completed[worldChange.currentBuildIndex] = true;
        GameObject.FindObjectOfType<SavedInfo>().playerHealth = _playerHealth.GetHealth();
        worldChange.ChangeScene();
    }
    public void Lose()
    {

    }
}
