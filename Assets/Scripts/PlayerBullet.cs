using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    private float timeToDestroy;

    private void Start()
    {
        timeToDestroy = 3.0f;
    }

    private void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy < 0.0f)
        {
            Destroy(gameObject);
        }
    }

}
