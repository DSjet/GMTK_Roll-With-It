using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldChange : MonoBehaviour
{
    public int currentBuildIndex;
    private int randNumber;
    int nextBuildIndex;
    public ValueRnd RouletteData;
    public Roulette roulette;

    GameObject holder;
    [SerializeField] Texture[] images = new Texture[6];

    void Start(){
        roulette = FindObjectOfType<Roulette>();
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        holder = GameObject.FindGameObjectWithTag("WorldIcon");
        holder.GetComponent<RawImage>().texture = images[currentBuildIndex];
    }
    public void ChangeScene(){
        switch (currentBuildIndex)
        {
            case 0:
                FindObjectOfType<SAudioManager>().StopPlay("Sea");
                break;
            case 1:
                FindObjectOfType<SAudioManager>().StopPlay("Forest");
                break;
            case 2:
                FindObjectOfType<SAudioManager>().StopPlay("Heaven");
                break;
            case 3:
                FindObjectOfType<SAudioManager>().StopPlay("Hell");
                break;
            case 4:
                FindObjectOfType<SAudioManager>().StopPlay("Desert");
                break;
            case 5:
                FindObjectOfType<SAudioManager>().StopPlay("Space");
                break;
        }
        roulette.ForceRoulette();
    }
}
