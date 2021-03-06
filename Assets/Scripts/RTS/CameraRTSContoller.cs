using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRTSContoller : MonoBehaviour
{
    public Camera viewCamera;

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 2.0f;

    public Vector2 panLimit;

    private void Update()
    {
        Vector3 pos = transform.position;


        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if(Input.GetKey("w") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        viewCamera.orthographicSize -= scroll * scrollSpeed * Time.deltaTime * 100f;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
    }
}
