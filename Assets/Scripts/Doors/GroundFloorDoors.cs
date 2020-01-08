using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundFloorDoors : MonoBehaviour
{

    private MeshRenderer groundFloorDoorMeshRenderer;
    private MeshCollider groundFloorDoorMeshCollider;
    private bool playerAnswer;
    private GroundFloorDoorsButtons groundFloorDoors;

    public Text groundFloorDoorsText;
    public GameObject groundFloorDoorsButtons;

    private void Start ()
    {
        groundFloorDoorMeshRenderer = GetComponent<MeshRenderer>();
        groundFloorDoorMeshCollider = GetComponent<MeshCollider>();
        groundFloorDoors = gameObject.AddComponent<GroundFloorDoorsButtons>();
        groundFloorDoors = FindObjectOfType<GroundFloorDoorsButtons>();
        groundFloorDoorsText.text = "";
        groundFloorDoorsText.transform.position = new Vector3(0.5f * Screen.width, 0.8f * Screen.height, 0);
        groundFloorDoorsButtons.transform.position = new Vector3(0.5f * Screen.width, 0.7f * Screen.height, 0);
        groundFloorDoorsButtons.SetActive(false);
    }

	private void Update ()
    {
        playerAnswer = groundFloorDoors.GetOpenDoors();
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
            if (playerAnswer)
            { 
                groundFloorDoorMeshRenderer.enabled = false;
                groundFloorDoorMeshCollider.enabled = false;
            }
            groundFloorDoorsText.text = gameObject.name.ToString();
            groundFloorDoorsButtons.SetActive(true);
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
            //groundFloorDoorMeshRenderer.enabled = true;
            //groundFloorDoorMeshCollider.enabled = true;
            groundFloorDoorsText.text = "";
            groundFloorDoorsButtons.SetActive(false);
        }
    }

}
