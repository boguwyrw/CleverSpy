using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundFloorDoors : MonoBehaviour
{

    private MeshRenderer groundFloorDoorMeshRenderer;
    private MeshCollider groundFloorDoorMeshCollider;
    private bool playerAnswer;

    public Text groundFloorDoorsText;

    private void Start ()
    {
        groundFloorDoorMeshRenderer = GetComponent<MeshRenderer>();
        groundFloorDoorMeshCollider = GetComponent<MeshCollider>();

        groundFloorDoorsText.text = "";
        groundFloorDoorsText.transform.position = new Vector3(0.5f * Screen.width, 0.8f * Screen.height, 0);
    }

	private void Update ()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            groundFloorDoorMeshRenderer.enabled = false;
            groundFloorDoorMeshCollider.enabled = false;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            groundFloorDoorMeshRenderer.enabled = false;
            groundFloorDoorMeshCollider.enabled = false;
            groundFloorDoorsText.text = gameObject.name.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            groundFloorDoorMeshRenderer.enabled = true;
            groundFloorDoorMeshCollider.enabled = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            groundFloorDoorMeshRenderer.enabled = true;
            groundFloorDoorMeshCollider.enabled = true;
            groundFloorDoorsText.text = "";
        }
    }

}
