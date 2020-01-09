using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementOpenDoorsSystem : MonoBehaviour
{

    private bool playerAnswer;
    private BasementDoorsButtons basementDoors;
    private MeshRenderer basementDoorMeshRenderer;
    private MeshCollider basementDoorMeshCollider;

    private void Start ()
    {
        playerAnswer = false;
        basementDoors = FindObjectOfType<BasementDoorsButtons>();
        basementDoorMeshRenderer = GetComponent<MeshRenderer>();
        basementDoorMeshCollider = GetComponent<MeshCollider>();
    }

    private void Update ()
    {
        playerAnswer = basementDoors.GetOpenDoors();
        if (playerAnswer)
        {
            basementDoorMeshRenderer.enabled = false;
            basementDoorMeshCollider.enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            if (playerAnswer)
            {
                basementDoorMeshRenderer.enabled = false;
                basementDoorMeshCollider.enabled = false;
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            basementDoorMeshRenderer.enabled = true;
            basementDoorMeshCollider.enabled = true;
        }
    }

}
