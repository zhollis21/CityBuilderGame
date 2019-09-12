using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const int EDGE_SIZE = 15;
    private const int CAMERA_SPEED = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Temporarily disabling this while testing, as it's annoying when not in full screen
        return;

        // ToDo: Update so it is slower at first and gets faster until max_speed

        Vector2 mousePosition = Input.mousePosition;

        // X Movement
        if (mousePosition.x < EDGE_SIZE)
            transform.position = new Vector3(transform.position.x - CAMERA_SPEED * Time.deltaTime, transform.position.y, transform.position.z);
        else if (mousePosition.x > Screen.width - EDGE_SIZE)
            transform.position = new Vector3(transform.position.x + CAMERA_SPEED * Time.deltaTime, transform.position.y, transform.position.z);

        // Y Movement
        if (mousePosition.y < EDGE_SIZE)
            transform.position = new Vector3(transform.position.x, transform.position.y - CAMERA_SPEED * Time.deltaTime, transform.position.z);
        else if (mousePosition.y > Screen.height - EDGE_SIZE)
            transform.position = new Vector3(transform.position.x, transform.position.y + CAMERA_SPEED * Time.deltaTime, transform.position.z);
    }
}
