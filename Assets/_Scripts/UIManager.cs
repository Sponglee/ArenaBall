using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    [SerializeField] private GameObject scoreElementPref;
    [SerializeField] private Transform uiContainer;

    public void InitializeScoreUI(CharController target)
    {

        GameObject tmpScoreElem = Instantiate(scoreElementPref, uiContainer);

        target.scoreTableRef = tmpScoreElem.transform.GetChild(0).GetComponent<Text>();
    }
 
    public void UpdateText(Text textField, string text)
    {
        textField.text = text;
    }
}
