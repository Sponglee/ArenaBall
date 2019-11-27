using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    

public class ScoreUpdater : MonoBehaviour
{

    [SerializeField] private Text nameRefText;
    [SerializeField] private Text scoreRefText;

    

    

    public void UpdateScore(string text)
    {

        scoreRefText.text = text;
    }

    public void UpdateName(string text)
    {
        nameRefText.text = text;
    }
}
