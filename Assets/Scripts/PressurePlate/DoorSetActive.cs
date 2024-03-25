using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor {

    private bool isDoorOpen = false;

    public void OpenDoor(){
        isDoorOpen = true;
        gameObject.SetActive(false);
    }

    public void CloseDoor(){
        isDoorOpen = false;
        gameObject.SetActive(true);
    }

    public void ToggleDoor()
    {
        isDoorOpen = !isDoorOpen;
        if (isDoorOpen)
        {
            OpenDoor();
        } else
        {
            CloseDoor();
        }
    }
}