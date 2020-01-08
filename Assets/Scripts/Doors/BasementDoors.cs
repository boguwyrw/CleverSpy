using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasementDoors : MonoBehaviour
{

    private MeshRenderer basementDoorMeshRenderer;
    private MeshCollider basementDoorMeshCollider;

    public Text basementDoorsText;
    public GameObject basementDoorsButtons;

    private void Start ()
    {
        basementDoorMeshRenderer = GetComponent<MeshRenderer>();
        basementDoorMeshCollider = GetComponent<MeshCollider>();
        basementDoorsText.text = "";
        basementDoorsText.transform.position = new Vector3(0.5f * Screen.width, 0.8f * Screen.height, 0);
        basementDoorsButtons.transform.position = new Vector3(0.5f * Screen.width, 0.7f * Screen.height, 0);
        basementDoorsButtons.SetActive(false);
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
            //basementDoorMeshRenderer.enabled = false;
            //basementDoorMeshCollider.enabled = false;
            basementDoorsText.text = gameObject.name.ToString();
            basementDoorsButtons.SetActive(true);
            Time.timeScale = 0.0f;
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
            //basementDoorMeshRenderer.enabled = true;
            //basementDoorMeshCollider.enabled = true;
            basementDoorsText.text = "";
            basementDoorsButtons.SetActive(false);
        }
    }

}
