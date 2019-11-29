using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FunctionHandler : Singleton<FunctionHandler>
{

    public string PlayerName = "Player1";
    public Text playerNameInput;

    public Slider slider;
    public Transform nextLevelButton;
 
    public Transform finish;
    public GameObject winCanvas;
   

   
    public GameObject scoreTablePref;
    public GameObject tmpScore;

    

    public CinemachineVirtualCamera finishCam;

    // Start is called before the first frame update
    void Start()
    {
        PlayerName = PlayerPrefs.GetString("PlayerName", "You");
        if(playerNameInput != null)
            playerNameInput.text = "Name: " + PlayerName;

      
       
    }






    //Check 
    public  void WinCheck(CharController target, int score)
    {



       if(LevelManager.Instance.levelGoal <= score)
       {
            
            WinSequence(target.transform);

            //TODO ADD "WON" LISTENER EVENT
            GameObject.FindGameObjectWithTag("Rival").GetComponent<AIMovementController>().StopAllCoroutines();
            GameObject.FindGameObjectWithTag("Rival").GetComponent<AIMovementController>().rivalInput = Vector3.zero;
       }
       

    }




    //Camera and menu sequence
    public void WinSequence(Transform player)
    {
        //if (PlayerPrefs.GetInt("LevelIndex", 0) + 1 <= LevelStorage.Instance.levelPrefabs.Length - 1 && LevelStorage.Instance.CurrentLevelIndex == LevelStorage.Instance.levelProgress)
        //{
        //    Debug.Log("SAVED LEVEL INDEX");
        //    PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex", 0) + 1);
        //    Debug.Log(PlayerPrefs.GetInt("LevelIndex", 0));
        //}


        winCanvas.SetActive(true);
     
        gameObject.SetActive(true);


        //if (winTmpData.name == PlayerName)
        finishCam.m_Priority = 199;
        finishCam.m_LookAt = player;


        //player.GetComponent<CharController>().anim.SetTrigger("Finish");

      

        //Freeze player in place
        player.GetComponent<Rigidbody>().isKinematic = true;

    
    }



  
    //Sort here
    public void SortTable(Transform scoreTableHolder)
    {
        //Flip table around

        for (int i = 0; i < scoreTableHolder.childCount; i++)
        {
            scoreTableHolder.GetChild(0).SetSiblingIndex(scoreTableHolder.childCount - 1 - i);
        }


        //Bubble sort
        for (int i = 0; i < scoreTableHolder.childCount; i++)
        {
            for (int j = 0; j < scoreTableHolder.childCount - 1 - i; j++)
            {


                float result;
                if (float.TryParse(scoreTableHolder.GetChild(j).GetChild(1).GetComponent<Text>().text, out result))
                {

                    if (float.Parse(scoreTableHolder.GetChild(j).GetChild(1).GetComponent<Text>().text) < float.Parse(scoreTableHolder.GetChild(j + 1).GetChild(1).GetComponent<Text>().text))
                    {
                        scoreTableHolder.GetChild(j).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150f);

                        Transform tmpScoreChild = scoreTableHolder.GetChild(j);
                        scoreTableHolder.GetChild(j + 1).SetSiblingIndex(j);
                        tmpScoreChild.SetSiblingIndex(j + 1);

                        //Reset width



                    }

                }
            }
        }

        //Set first child to be wider
        scoreTableHolder.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 177f);
 
    }


   




    ////////////UI FUNCTIONS///////////////////
    public Transform menuCanvas;
   
    public Transform uiCanvas;


    public Text menuText;

    public void Restart(string level)
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(level);
    }


    public void LevelComplete()
    {

        menuText.text = "YOU WIN";
        winCanvas.gameObject.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void Pause()
    {
        //menuText.text = GameManager.Instance.Score.ToString();
        uiCanvas.gameObject.SetActive(!uiCanvas.gameObject.activeSelf);
        menuCanvas.gameObject.SetActive(!menuCanvas.gameObject.activeSelf);


        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
        else if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }

    public void GameOver()
    {
       

        StartCoroutine(GameOverDelay());
    }

    public IEnumerator GameOverDelay()
    {

        //if (LevelStorage.Instance.levelProgress > LevelStorage.Instance.CurrentLevelIndex) 
        //    nextLevelButton.gameObject.SetActive(true);
        //else
        //    nextLevelButton.gameObject.SetActive(false);

        menuText.text = "GAME OVER";
        uiCanvas.gameObject.SetActive(!uiCanvas.gameObject.activeSelf);
        winCanvas.gameObject.SetActive(!winCanvas.gameObject.activeSelf);


        yield return new WaitForSeconds(2f);



        //Get everyother score and show them
        //Highscores.Instance.DownloadHighscores(LevelStorage.Instance.CurrentLevelIndex, true);
        //tmpScore.gameObject.SetActive(false);
        //SortTable();


        yield return new WaitForSeconds(3f);

        if (Time.timeScale == 1f)
            Time.timeScale = 0f;
        else if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }



    public void SavePlayerName(InputField input)
    {


        string formattedPlayer = Clean(input.text);

        //Clean off unwanted characters
        string Clean(string s)
        {
            s = s.Replace("/", "");
            s = s.Replace("|", "");
            s = s.Replace("*", "");
            return s;

        }

        PlayerPrefs.SetString("PlayerName", formattedPlayer);
    }



    ////Tower pick
    //public GameObject GrabRayObj(string target)
    //{



    //    Vector3 rayPos = Input.mousePosition;
    //    rayPos.z = Camera.main.farClipPlane;

    //    rayPos = Camera.main.ScreenToWorldPoint(rayPos);





    //    Debug.DrawLine(rayPos, Camera.main.transform.position, Color.red, 5f);

    //    RaycastHit[] hits = Physics.RaycastAll(Camera.main.transform.position, rayPos);

    //    if (hits.Length != 0)
    //    {
    //        foreach (var hit in hits)
    //        {
    //            if (hit.collider.CompareTag(target))
    //            {
    //                GameObject objectHit = hit.transform.gameObject;
    //                Debug.Log(objectHit.tag);
    //                return objectHit;

    //            }

    //        }
    //    }


    //    return null;
    //}




}
