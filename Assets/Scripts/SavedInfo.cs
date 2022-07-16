using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavedInfo : MonoBehaviour
{
    public static SavedInfo savedInfo { get; private set; }

    public int playerHealth;
    public int levelsCompleted;
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
    

}
