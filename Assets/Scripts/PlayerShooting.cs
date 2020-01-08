using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    private Vector3 playerBulletStartPosition;
    private float playerBulletSpeed;
    private float fireRate;
    private float nextFire;

    public GameObject playerGun;
    public Rigidbody playerBullet;

    private void Start()
    {
        playerBulletSpeed = 1200.0f;
        fireRate = 1.0f;
        nextFire = Time.time;
    }

    private void FixedUpdate()
    {
        playerBulletStartPosition = playerGun.transform.position;

        if (Input.GetButtonDown("Fire1") && (Time.time > nextFire))
        {
            Rigidbody bulletClone;
            bulletClone = Instantiate(playerBullet, playerBulletStartPosition, transform.rotation);
            bulletClone.velocity = transform.TransformDirection(Vector3.forward * playerBulletSpeed * Time.deltaTime);
            nextFire = Time.time + fireRate;
        }
    }

}
