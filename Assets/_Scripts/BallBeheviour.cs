using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBeheviour : MonoBehaviour
{
    private Rigidbody _rb;
    private bool IsTriggered = false;

    [SerializeField] private GameObject lastContact;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //_rb.AddForce(new Vector3(Random.Range(-1f, 1f)+ 0f, 1f, /*Random.Range(-1f, 1f)*/0f));
        }
        else if(collision.gameObject.CompareTag("Wall"))
        {
            collision.transform.parent.parent.GetComponent<WallHitReact>().WallReact();

            _rb.AddForce(new Vector3(0f, 1f, 0f) + 2f*(collision.transform.position- transform.position).normalized);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            lastContact = collision.gameObject;

            _rb.AddForce(new Vector3((transform.position.x - collision.transform.position.x), 
                0f, 
                (transform.position.z - collision.transform.position.z))*15f + Vector3.up*1f);
        }
        else if (collision.gameObject.CompareTag("Rival"))
        {
            lastContact = collision.gameObject;

            _rb.AddForce(new Vector3((transform.position.x - collision.transform.position.x),
                0f,
                (transform.position.z - collision.transform.position.z)) * 15f + Vector3.up * 1f);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!IsTriggered && other.CompareTag("Exit"))
        {
            if (lastContact != null)
            {
                lastContact.GetComponent<CharController>().UpdateScore();
                other.transform.parent.parent.GetComponent<WallHitReact>().WallReact();
                IsTriggered = true;
                //SpawnManager.Instance.SpawnBall();
                SpawnManager.Instance.DetatchBall(transform);
            }
            else
            {
                SpawnManager.Instance.DetatchBall(transform);
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(gameObject);
        }
    }
}
