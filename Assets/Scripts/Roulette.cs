using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette : MonoBehaviour
{

    //References
    public GameObject DiceSix;
    public GameObject DiceTwenty;
    public ValueRnd TotalEnemy;
    private Vector2 InitialDiceSixValue;
    private Vector2 InitialDiceTwentyValue;
    private Rigidbody2D D6Rb;
    private Rigidbody2D D20Rb;
    public float force = 10f;
    public float friction = 1f;
    private float currForce;
    

    public void Start(){
        InitialDiceSixValue.Set(-6.094859f, -0.768065f);
        InitialDiceTwentyValue.Set(-5.65f, 0.76f);
        D6Rb = DiceSix.GetComponent<Rigidbody2D>();
        D20Rb = DiceTwenty.GetComponent<Rigidbody2D>();
    }

    // Roll Dice Function
    public void RollDiceSix(){
        int RandomizedValue = (TotalEnemy.LastMap + Random.Range(1,5)) % 6;
        TotalEnemy.LastMap = RandomizedValue;
        animationShowDice6(RandomizedValue);
    }

    public void RollDiceTwenty(){
        int RandomizedValue = Random.Range(1,20);
        TotalEnemy.TotalEnemy += RandomizedValue;
        animationShowDice20(RandomizedValue);
    }

    private void animationShowDice6(int value){
        DiceSix.transform.position = InitialDiceSixValue;
        DiceSix.SetActive(true);
    }

    private void animationShowDice20(int value){
        DiceTwenty.transform.position = InitialDiceTwentyValue;
        DiceTwenty.SetActive(true);
    }

    public void startRoulette(){
        currForce = force;
        RollDiceSix();
        RollDiceTwenty();
    }

    public void stopRoulette(){
        DiceSix.SetActive(false);
        DiceTwenty.SetActive(false);
    }

    public void FixedUpdate(){
        if(currForce > 0){
            currForce -= friction;
            D6Rb.AddForce(new Vector2(currForce * Time.deltaTime, 0));
            D20Rb.AddForce(new Vector2(currForce * Time.deltaTime, 0));
        }
    }

    public void resetSOValue(){
        TotalEnemy.TotalEnemy = 0;
        TotalEnemy.LastMap = 0;
    }
}
