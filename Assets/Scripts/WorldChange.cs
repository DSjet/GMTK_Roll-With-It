using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldChange : MonoBehaviour
{
    Scene currentWorld;
    public int currentBuildIndex;
    private int randNumber;
    int nextBuildIndex;

    GameObject holder;
    [SerializeField] Texture[] images = new Texture[6];

    void Start(){
        currentWorld = SceneManager.GetActiveScene();
        currentBuildIndex = currentWorld.buildIndex;
        randNumber = Random.Range(0,6);
        while(randNumber == currentBuildIndex){
            randNumber = Random.Range(0,6);
        }
        nextBuildIndex = randNumber;

        holder = GameObject.FindGameObjectWithTag("WorldIcon");
        holder.GetComponent<RawImage>().texture = images[currentBuildIndex];
    }
    public void ChangeScene(){
        //enter things to do before next scene here
        //...
        SceneManager.LoadScene(nextBuildIndex);
    }
}
