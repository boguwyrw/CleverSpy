using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    private Vector2 mouseDirection;
    private Transform playerBody;
    private float verticalRotation = 0.0f;
    private float horizontalRotation = 0.0f;
    private float rotationLimit = 60.0f;

    public Camera playerCamera;

    void Start()
    {
        playerBody = transform.parent.transform;
    }

    void FixedUpdate()
    {
        horizontalRotation = Input.GetAxis("Mouse X");
        verticalRotation = Input.GetAxis("Mouse Y");

        Vector2 mouseChange = new Vector2(horizontalRotation, verticalRotation);

        mouseDirection += mouseChange;

        mouseDirection.y = Mathf.Clamp(mouseDirection.y, -rotationLimit, rotationLimit);

        transform.localRotation = Quaternion.AngleAxis(-mouseDirection.y, Vector3.right);
        playerBody.localRotation = Quaternion.AngleAxis(mouseDirection.x, Vector3.up);
    }

}
