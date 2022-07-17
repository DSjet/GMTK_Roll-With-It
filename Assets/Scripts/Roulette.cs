using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Roulette : MonoBehaviour
{

    //References
    public Image DiceSix;
    public Sprite[] DiceSixSprites;
    public TMP_Text DiceTwenty;
    public ValueRnd TotalEnemy;
    public int RandomizerDice = 15;
    public float RandomizerWaitTime = 0.05f;
    private int resDice6;
    private int resDice20;

    // Roll Dice Function
    public void RollDiceSix(){
        int RandomizedValue = (TotalEnemy.LastMap6Dice + Random.Range(1,5)) % 6;
        resDice6 = RandomizedValue;
        TotalEnemy.LastMap6Dice = RandomizedValue;
    }

    public void RollDiceTwenty(){
        int RandomizedValue = Random.Range(1,20);
        resDice20 = RandomizedValue;
        TotalEnemy.SpawnEnemies20Dice = RandomizedValue;
        StartCoroutine("animateAll");
    }

    private IEnumerator animationShowDice6(){
        for(int i = 0; i < RandomizerDice; i++){
            DiceSix.sprite = DiceSixSprites[Random.Range(0,5)];
            yield return new WaitForSeconds(RandomizerWaitTime);
        }
        DiceSix.sprite = DiceSixSprites[resDice6];
    }

    private IEnumerator animateAll(){
        for(int i = 0; i < RandomizerDice; i++){
            DiceSix.sprite = DiceSixSprites[Random.Range(0,5)];
            DiceTwenty.SetText(Random.Range(1,20).ToString());
            yield return new WaitForSeconds(RandomizerWaitTime);
        }
        DiceSix.sprite = DiceSixSprites[resDice6];
        DiceTwenty.SetText(resDice20.ToString());
    }

    private IEnumerator animationShowDice20(){
        for(int i = 0; i < RandomizerDice; i++){
            DiceTwenty.SetText(Random.Range(1,20).ToString());
            yield return new WaitForSeconds(RandomizerWaitTime);
        }
        DiceTwenty.SetText(resDice20.ToString());
    }


    public void startRoulette(){
        RollDiceSix();
        RollDiceTwenty();
    }

    public void resetSOValue(){
        TotalEnemy.SpawnEnemies20Dice = 0;
        TotalEnemy.LastMap6Dice = 0;
    }
}
