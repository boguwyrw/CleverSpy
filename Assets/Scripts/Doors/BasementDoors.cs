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
        basementDoorsText.transform.position = new Vector3(0.5f * Screen.width, 0.8f * Screen.height, 0);;
    }

	private void Update ()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            basementDoorMeshRenderer.enabled = false;
            basementDoorMeshCollider.enabled = false;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            basementDoorMeshRenderer.enabled = false;
            basementDoorMeshCollider.enabled = false;
            basementDoorsText.text = gameObject.name.ToString();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            basementDoorMeshRenderer.enabled = true;
            basementDoorMeshCollider.enabled = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            basementDoorMeshRenderer.enabled = true;
            basementDoorMeshCollider.enabled = true;
            basementDoorsText.text = "";
        }
    }

}
