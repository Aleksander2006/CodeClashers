using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSetActive : MonoBehaviour, IPressurePlate {

    private bool isOpen = false;

    public void OpenSignal() {
        isOpen = true;
        gameObject.SetActive(false);
    }

    public void CloseSignal() {
        isOpen = false;
        gameObject.SetActive(true);
    }

    public void ToggleSignal() {
        isOpen = !isOpen;
        if (isOpen){
            OpenSignal();
        } else{
            CloseSignal();
        }
    }
}
