using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    [SerializeField] private float wallReactTime = 0.5f;
    [SerializeField] private bool IsReacting = false;
    [SerializeField] private Color startColor;
    [SerializeField] private Transform modelRef;
    private Material matRef;

    private void Start()
    {
        matRef = modelRef.GetComponent<Renderer>().material;
        startColor = matRef.GetColor("_EmissionColor");
    }

    public void WallReact()
    {
        //if (!IsReacting)
        //{

        //}

        IsReacting = true;
        StopCoroutine(StopWallReact());
        matRef.SetColor("_EmissionColor", startColor);
        StartCoroutine(StopWallReact());
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
