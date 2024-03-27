using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor {

    private bool isDoorOpen = false;
    public bool isDoorOpen1 = false;
    public bool isDoorOpen2 = false;

    public bool isLampOn2 = false;

    public void Update(){
        DoorSignal3();
    }
    public void OpenDoor(){
        isDoorOpen = true;
        gameObject.SetActive(false);
    }

    public void CloseDoor(){
        isDoorOpen = false;
        gameObject.SetActive(true);
    }

    public void DoorSignal1(){
        isDoorOpen1 = true;
        gameObject.SetActive(true);
    }

    public void DoorSignal2(){
        isDoorOpen2 = true;
        gameObject.SetActive(true);
    }

    public void DoorSignalClose1(){
        isDoorOpen1 = false;
        isDoorOpen = false;
    }

    public void DoorSignalClose2(){
        isDoorOpen2 = false;
        isDoorOpen = false;
    }

    public void DoorSignal3(){
        if(isDoorOpen1 && isDoorOpen2){
            if(!isDoorOpen){
                OpenDoor();
            }
        }
    } 
}