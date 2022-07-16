using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldChange : MonoBehaviour
{
    Scene currentWorld;
    int currentBuildIndex;
    private int randNumber;
    int nextBuildIndex;

    void Start(){
        currentWorld = SceneManager.GetActiveScene();
        currentBuildIndex = currentWorld.buildIndex;
        randNumber = Random.Range(0,5);
        while(randNumber == currentBuildIndex){
            randNumber = Random.Range(0,5);
        }
        nextBuildIndex = randNumber; 
    }
    public void ChangeScene(){
        SceneManager.LoadScene(nextBuildIndex);
    }
}
