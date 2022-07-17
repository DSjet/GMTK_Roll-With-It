using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTrack : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    private void Start()
    {
        textDisplay.text = SavedInfo.enemiesKilled.ToString();
    }
    private void FixedUpdate()
    {
        textDisplay.text = SavedInfo.enemiesKilled.ToString();
    }
}
