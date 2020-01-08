using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorDoors : MonoBehaviour
{

    private MeshRenderer groundFloorDoorMeshRenderer;
    private MeshCollider groundFloorDoorMeshCollider;

    private void Start ()
    {
        groundFloorDoorMeshRenderer = GetComponent<MeshRenderer>();
        groundFloorDoorMeshCollider = GetComponent<MeshCollider>();
    }

	private void Update ()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            groundFloorDoorMeshRenderer.enabled = false;
            groundFloorDoorMeshCollider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            groundFloorDoorMeshRenderer.enabled = true;
            groundFloorDoorMeshCollider.enabled = true;
        }
    }

}
