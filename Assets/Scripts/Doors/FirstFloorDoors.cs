using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorDoors : MonoBehaviour
{

    private MeshRenderer firstFloorDoorMeshRenderer;
    private MeshCollider firstFloorDoorMeshCollider;

    private void Start()
    {
        firstFloorDoorMeshRenderer = GetComponent<MeshRenderer>();
        firstFloorDoorMeshCollider = GetComponent<MeshCollider>();
    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            firstFloorDoorMeshRenderer.enabled = false;
            firstFloorDoorMeshCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            firstFloorDoorMeshRenderer.enabled = true;
            firstFloorDoorMeshCollider.enabled = true;
        }
    }

}
