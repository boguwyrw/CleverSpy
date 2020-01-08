using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    private float playerSpeed = 7.0f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        float movementVertical = Input.GetAxis("Vertical");
        movementVertical *= Time.deltaTime;
        transform.Translate(Vector3.forward * movementVertical * playerSpeed);

        float movementHorizontal = Input.GetAxis("Horizontal");
        movementHorizontal *= Time.deltaTime;
        transform.Translate(new Vector3(movementHorizontal * playerSpeed, 0.0f, 0.0f));
    }

}
