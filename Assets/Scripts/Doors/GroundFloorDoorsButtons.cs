using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloorDoorsButtons : MonoBehaviour
{

    private bool openDoors;

    private void Start ()
    {
        openDoors = false;
    }

    private void Update ()
    {
		
	}

    public bool GetOpenDoors()
    {
        return openDoors;
    }

    public void SelectedAnswerYes()
    {
        openDoors = true;
    }

    public void SelectedAnswerNo()
    {
        openDoors = false;
    }

}
