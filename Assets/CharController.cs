using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    public Text scoreTableRef;
    [SerializeField] private int score;
    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    private void Start()
    {
        UIManager.Instance.InitializeScoreUI(this);
    }

    public void UpdateScore()
    {


        Score++;
        UIManager.Instance.UpdateText(scoreTableRef, Score.ToString());


    }

}
