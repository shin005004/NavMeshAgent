using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Camera
    public Camera viewCamera;
    public LayerMask MousePositionPlane;

    // For PlayerMovements
    private Rigidbody playerRigidbody;
    public NavMeshAgent playerAgent;
    [Tooltip("To Use LookAt at the caracter controller uncheck this")]
    public bool isUpdateRotation = false;

    void Start()
    {
        if(playerAgent == null)
        {
            Debug.Log("PlayerAgent not Assigned using default agent instead");
            playerAgent = GetComponent<NavMeshAgent>();
        }
        playerAgent.updateRotation = isUpdateRotation;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 mousePos = Vector3.zero;
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        // LookAt MousePosition
        if(Physics.Raycast(ray, out hit, 100.0f, MousePositionPlane))
        {
            mousePos = hit.point;
        }
        mousePos.y = transform.position.y;
        transform.LookAt(mousePos);

        // Move to MousePos if leftbutton is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100.0f, MousePositionPlane))
            {
                // Move agents with setDestination()
                playerAgent.SetDestination(hit.point);
                Debug.Log(hit.point);
            }
        }
    }
}
