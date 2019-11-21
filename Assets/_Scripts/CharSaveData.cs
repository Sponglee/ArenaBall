using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewBaseCard", menuName = "Card/BaseCard")]
public class CharSaveData :ScriptableObject
{
    public int Score;
    public Text ScoreTextRef;
    public string Name;

}
