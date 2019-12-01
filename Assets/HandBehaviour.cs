using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    public Transform hand;
    public Transform target;

    private Vector3 initialMousePosition;

    public float stringValue = 0f;
    [SerializeField] private float circleRadius;
    [SerializeField] private float springK = 1f;
    [SerializeField] private float force = 1f;
    [SerializeField] private Collider handCol;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            StopCoroutine(StopReleaseSpring());
            hand.localPosition = Vector3.zero;
            handCol.enabled = false;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("Floor");
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                hand.position = hit.point;
                hand.gameObject.SetActive(true);

                initialMousePosition = hit.point;
                transform.position = hit.point;

                target.position = hit.point;
                target.gameObject.SetActive(true);
            }
        }
        else if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("Floor");
            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                hand.position = hit.point;
                hand.LookAt(transform);
                
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            
            ReleaseSpring();

        }
    }


    public void ReleaseSpring()
    {
        handCol.enabled = true;
        if (Mathf.Approximately(hand.localPosition.x, 0f) && Mathf.Approximately(hand.localPosition.z, 0f))
        {
            hand.gameObject.SetActive(false);
            target.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(StopReleaseSpring());
            
        }

    }

    public IEnumerator StopReleaseSpring()
    {
        float duration = 0.5f;
        float elapsed = 0f;
        Vector3 startPos = hand.localPosition;
        while(/*hand.localPosition != Vector3.zero*/ elapsed<duration)
        {
            hand.localPosition = Vector3.Lerp(startPos, (Vector3.zero-startPos).normalized*springK, elapsed / duration*springK);
            elapsed += Time.deltaTime;
            yield return null;
        }
        hand.gameObject.SetActive(false);
        target.gameObject.SetActive(false);
    }

}


