using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBeheviour : MonoBehaviour
{
    private Rigidbody _rb;

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
            _rb.AddForce(new Vector3(0f, 1f, 0f) + 2f*(collision.transform.position- transform.position).normalized);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            _rb.AddForce(new Vector3((transform.position.x - collision.transform.position.x), 
                0f, 
                (transform.position.z - collision.transform.position.z))*15f + Vector3.up*1f);
        }
        else if(collision.gameObject.CompareTag("Exit"))
        {
            BallSpawner.Instance.SpawnBall();
            Destroy(gameObject);
        }
    }
}
