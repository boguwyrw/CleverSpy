using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstFloorDoors : MonoBehaviour
{

    private MeshRenderer firstFloorDoorMeshRenderer;
    private MeshCollider firstFloorDoorMeshCollider;

    public Text firstFloorDoorsText;

    private void Start()
    {
        firstFloorDoorMeshRenderer = GetComponent<MeshRenderer>();
        firstFloorDoorMeshCollider = GetComponent<MeshCollider>();
        firstFloorDoorsText.text = "";
        firstFloorDoorsText.transform.position = new Vector3(0.5f * Screen.width, 0.8f * Screen.height, 0);
    }

    private void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            OpenFirstFloorDoor();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            OpenFirstFloorDoor();
            firstFloorDoorsText.text = gameObject.name.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CloseFirstFloorDoor();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            CloseFirstFloorDoor();
            firstFloorDoorsText.text = "";
        }
    }

    private void OpenFirstFloorDoor()
    {
        firstFloorDoorMeshRenderer.enabled = false;
        firstFloorDoorMeshCollider.enabled = false;
    }

    private void CloseFirstFloorDoor()
    {
        firstFloorDoorMeshRenderer.enabled = true;
        firstFloorDoorMeshCollider.enabled = true;
    }

}
