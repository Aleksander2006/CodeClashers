using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor {

    private bool isDoorOpen = false;
    private bool isDoorOpen1 = false;
    private bool isDoorOpen2 = false;

    public void OpenDoor(){
        isDoorOpen = true;
        gameObject.SetActive(false);
    }

    public void CloseDoor(){
        isDoorOpen = false;
        gameObject.SetActive(true);
    }

    public void DoorSignal1(){
        isDoorOpen1 = false;
        gameObject.SetActive(true);
    }

    public void DoorSignal2(){
        isDoorOpen2 = false;
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