using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

public class WallHitReact : MonoBehaviour
{
    [SerializeField] private float wallReactTime = 0.5f;
    [SerializeField] private bool IsReacting = false;
    [SerializeField] private Color startColor;
    [SerializeField] private Transform modelRef;
    private Material matRef;

    [SerializeField] private Transform blockers;
    [SerializeField] private bool IsBlocking = false;
    [SerializeField] private Vector3 colliderSides;
    public bool IsInner = false;
    private void Start()
    {

        if(IsBlocking)
        {
            blockers.gameObject.SetActive(true);
        }
        if(IsInner)
        {

        }
        matRef = modelRef.GetComponent<Renderer>().material;
        startColor = matRef.GetColor("_EmissionColor");
    }

    public void WallReact()
    {
       
        if(true)
        {
            IsReacting = true;
            StopCoroutine(StopWallReact());
            matRef.SetColor("_EmissionColor", startColor);
            StartCoroutine(StopWallReact());
        }

        
    }



    private IEnumerator StopWallReact()
    {
       
        Color finalColor = matRef.GetColor("_EmissionColor") * Mathf.LinearToGammaSpace(2f);
        finalColor *= 4.0f; //  4X brighter
        matRef.SetColor("_EmissionColor", finalColor);
        
       
        yield return new WaitForSeconds(wallReactTime);
        matRef.SetColor("_EmissionColor", startColor);
        IsReacting = false;

    }
}
