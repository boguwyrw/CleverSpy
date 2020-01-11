using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundFloorDoors : MonoBehaviour
{

    private MeshRenderer groundFloorDoorMeshRenderer;
    private MeshCollider groundFloorDoorMeshCollider;

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
            OpenGroundFloorDoor();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            OpenGroundFloorDoor();
            groundFloorDoorsText.text = gameObject.name.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CloseGroundFloorDoor();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            CloseGroundFloorDoor();
            groundFloorDoorsText.text = "";
        }
    }

    private void OpenGroundFloorDoor()
    {
        groundFloorDoorMeshRenderer.enabled = false;
        groundFloorDoorMeshCollider.enabled = false;
    }

    private void CloseGroundFloorDoor()
    {
        groundFloorDoorMeshRenderer.enabled = true;
        groundFloorDoorMeshCollider.enabled = true;
    }

}
