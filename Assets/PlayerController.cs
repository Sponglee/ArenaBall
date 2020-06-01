
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Transform ballRef;
    public float forceValue = 10f;

    public LayerMask myLayerMask;

    [SerializeField] private InputManager _inputManager;

    private Rigidbody rb;


    private void Start()
    {
       
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
            if (Physics.Raycast(ray,out hit,100f,myLayerMask))
            {
                Debug.Log(hit.transform.gameObject.tag);
                if(hit.transform.CompareTag("Ball"))
                {
                    
                    ballRef = hit.transform;
                    rb = ballRef.GetComponent<Rigidbody>();
                    transform.position = ballRef.position;
                    ballRef.tag = "Player";
                }
                else
                {
                    ballRef = null;
                }
            }
            else
            {
                ballRef = null;
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(ballRef != null)
                ballRef.position = transform.position + _inputManager.charInput;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(ballRef != null)
            {
              
                LaunchBall(ballRef.position - transform.position);
            }
        }
    }

    private void LaunchBall(Vector3 launchPosition)
    {
        rb.AddForce((-launchPosition)*forceValue, ForceMode.Impulse);

        
    }

    
}
