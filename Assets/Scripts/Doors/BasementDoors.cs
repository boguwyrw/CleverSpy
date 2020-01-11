using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasementDoors : MonoBehaviour
{

    private MeshRenderer basementDoorMeshRenderer;
    private MeshCollider basementDoorMeshCollider;

    public Text basementDoorsText;

    private void Start ()
    {
        basementDoorMeshRenderer = GetComponent<MeshRenderer>();
        basementDoorMeshCollider = GetComponent<MeshCollider>();
        basementDoorsText.text = "";
        basementDoorsText.transform.position = new Vector3(0.5f * Screen.width, 0.8f * Screen.height, 0);
    }

	private void Update ()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            OpenBasementDoor();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            OpenBasementDoor();
            basementDoorsText.text = gameObject.name.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            CloseBasementDoor();
        }

        if (other.gameObject.CompareTag("Player"))
        {
            CloseBasementDoor();
            basementDoorsText.text = "";
        }
    }

    private void OpenBasementDoor()
    {
        basementDoorMeshRenderer.enabled = false;
        basementDoorMeshCollider.enabled = false;
    }

    private void CloseBasementDoor()
    {
        basementDoorMeshRenderer.enabled = true;
        basementDoorMeshCollider.enabled = true;
    }

}
