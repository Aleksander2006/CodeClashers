using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor {

    private bool isDoorOpen = false;
    public bool isDoorOpen1 = false;
    public bool isDoorOpen2 = false;
    public bool isLampOn2 = false;

    public void Update() {
        DoorSignal3();
    }

    //Hide de closed door
    public void OpenDoor() {
        isDoorOpen = true;
        gameObject.SetActive(false);
    }

    //Showd de closed door
    public void CloseDoor() {
        isDoorOpen = false;
        gameObject.SetActive(true);
    }

    //AND levers signaal voor de deur
    public void DoorSignal1() {
        isDoorOpen1 = true;
        gameObject.SetActive(true);
    }

    //PressurePlate signaal voor de deur
    public void DoorSignal2() {
        isDoorOpen2 = true;
        gameObject.SetActive(true);
    }

    //Reset de values van signalen van AND lampje
    public void DoorSignalClose1() {
        isDoorOpen1 = false;
        isDoorOpen = false;
    }

    //Reset de values van signalen van PressurePlate lampje
    public void DoorSignalClose2() {
        isDoorOpen2 = false;
        isDoorOpen = false;
    }

    //Checkt of de signalen van bijde lampjes aan zijn, opent dan de deur
    public void DoorSignal3() {
        if(isDoorOpen1 && isDoorOpen2){
            if(!isDoorOpen){
                OpenDoor();
            }
        }
    } 
}