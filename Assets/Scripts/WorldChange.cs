using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldChange : MonoBehaviour
{
    Scene currentWorld;
    int currentBuildIndex;
    private int randNumber;
    int nextBuildIndex;

    GameObject holder;
    [SerializeField] Texture[] images = new Texture[6];

    void Start(){
        currentWorld = SceneManager.GetActiveScene();
        currentBuildIndex = currentWorld.buildIndex;
        randNumber = Random.Range(0,5);
        while(randNumber == currentBuildIndex){
            randNumber = Random.Range(0,5);
        }
        nextBuildIndex = randNumber;

        holder = GameObject.FindGameObjectWithTag("WorldIcon");
        holder.GetComponent<RawImage>().texture = images[currentBuildIndex];
    }
    public void ChangeScene(){
        SceneManager.LoadScene(nextBuildIndex);
    }
}
