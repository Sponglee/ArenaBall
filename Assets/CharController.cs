using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    [SerializeField] private RivalStaticData botNames;

    [SerializeField] private ScoreUpdater scoreTableRef;
    public ScoreUpdater ScoreTableRef
    {
        get
        {
            return scoreTableRef;
        }

        set
        {
            scoreTableRef = value;
        }
    }

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
        if(botNames == null)
        {

            scoreTableRef.UpdateName(PlayerPrefs.GetString("PlayerName","You"));
        }
        else
        {
            scoreTableRef.UpdateName(botNames.RivalNames[Random.Range(0,botNames.RivalNames.Length)]);
        }
        scoreTableRef.UpdateScore(Score.ToString());
    }

    public void UpdateScore()
    {


        Score++;
        scoreTableRef.UpdateScore(Score.ToString());


    }

}
