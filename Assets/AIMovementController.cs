using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementController : MonoBehaviour
{
    [SerializeField] private Transform targetBall;
    [SerializeField] private Transform targetTarget;
    [SerializeField] private Vector3 destination;

    public Vector3 rivalInput = Vector3.zero;


    private Transform _ballHolder;  
    [SerializeField] private GameObject[] walls;
    [SerializeField] private GameObject[] exits;
    [SerializeField] private GameObject[] players;

    [SerializeField] private float moveDistance = 0.1f;
    [SerializeField] private float targetBreakDistance = 2f;

    public bool Kicked = false;
    

    private void Start()
    {
        FunctionHandler.OnGameOver += StopAI;


            _ballHolder = SpawnManager.Instance.ballHolder;
        walls = GameObject.FindGameObjectsWithTag("Wall");
        exits = GameObject.FindGameObjectsWithTag("Exit");
        players = GameObject.FindGameObjectsWithTag("Player");


        targetTarget = GetTarget();

        StartCoroutine(BehaviourRunner());
    }

    public void StopAI()
    {
        StopAllCoroutines();
        rivalInput = Vector3.zero;
    }

    private IEnumerator BehaviourRunner()
    {
        while(true)
        {
            if (targetBall != null && targetBall.parent != null)
            {
                Debug.DrawLine(transform.position, targetBall.position, Color.red);
                Debug.DrawLine(targetBall.position, targetTarget.position, Color.green);
                Debug.DrawLine(targetBall.position, targetBall.position + (targetBall.position - targetTarget.position).normalized, Color.black);




                destination = targetBall.position + (targetBall.position - targetTarget.position).normalized;
                Debug.DrawLine(transform.position, destination, Color.white);

                UpdateAIJoystic(destination);


            }
            else if (_ballHolder.childCount > 0)
            {
                ChangeTarget();
            }
            else
            {
                UpdateAIJoystic(Vector3.zero);
            }
            yield return null;
        }
       
    }



    private void UpdateAIJoystic(Vector3 desto)
    {
        if (Vector3.Magnitude(desto - transform.position) > targetBreakDistance)
        {
            Debug.Log("HERE");
            rivalInput = Vector3.zero;
            ChangeTarget();
        }
        else if (Vector3.Magnitude(desto - transform.position) <= moveDistance)
        {
            rivalInput = new Vector3((targetBall.position - transform.position).normalized.x, 
                0f, (targetBall.position - transform.position).normalized.z);
        }
        else if(desto == Vector3.zero)
        {
            rivalInput = Vector3.zero;
        }
        else
            rivalInput = new Vector3((desto - transform.position).normalized.x, 0f, (desto - transform.position).normalized.z);
    }

    //Choose a target
    public Transform GetTarget()
    {
        targetBall = _ballHolder.GetChild(Random.Range(0, _ballHolder.childCount));

        Transform chosenTarget = null;

        int roll = Random.Range(0, 100);

        //Target Exit
        if(roll<=50)
        {
            chosenTarget = walls[Random.Range(0, walls.Length)].transform;
        }
        //Target wall
        else if(roll>50 && roll <=80)
        {
            chosenTarget = exits[Random.Range(0, exits.Length)].transform;
        }
        //Target player
        else
        {
            chosenTarget = players[Random.Range(0, players.Length)].transform;
        }

        return chosenTarget;
    }


    public void ChangeTarget()
    {
        targetBall = null;
        targetTarget = GetTarget();
    }
}
