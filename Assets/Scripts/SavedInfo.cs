using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedInfo : MonoBehaviour
{
    public static SavedInfo savedInfo { get; private set; }

    public int playerHealth;
    public int levelsCompleted;
    public static int enemiesKilled = 0;
    public bool[] completed = new bool[6];

    void Awake()
    {
        if (savedInfo != null && savedInfo != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            savedInfo = this;
        }
    }

    public void ResetSaves()
    {
        //skills
        PlayerPrefs.SetInt("a1", 0);
        PlayerPrefs.SetInt("a2", 0);
        PlayerPrefs.SetInt("a3", 0);
        PlayerPrefs.SetInt("a4", 0);
        PlayerPrefs.SetInt("a5", 0);
        PlayerPrefs.SetInt("a6", 0);

        //game progress save
        enemiesKilled = 0;
        levelsCompleted = 0;
        playerHealth = 6;

        for (int i = 0; i < completed.Length; i++)
        {
            completed[i] = false;
        }
    }


}
