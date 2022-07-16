using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }
    public WorldChange worldChange;
    public UnitHealth _playerHealth = new UnitHealth(6,6);

    public int enemiesRemaining = 1;

    private void Awake()
    {
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
        worldChange.ChangeScene();
    }
    public void Lose()
    {

    }
}
