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
        roulette.ForceRoulette();
    }
}
