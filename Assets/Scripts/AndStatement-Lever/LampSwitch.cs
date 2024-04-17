using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour, Ilamp {

    private bool isLeverOn1 = false;
    private bool isLeverOn2 = false;

    public void Start() {
        isLeverOn1 = true;
        isLeverOn2 = true;
    }

    public void leverOnSignal() {
        // isLeverOn1 = false;
        if (isLeverOn1) {
            isLeverOn1 = false;
        }
        if (isLeverOn2) {
            isLeverOn2 = false;
        }
    }


    public void leverOffSignal() {
        gameObject.SetActive(true);
        if (isLeverOn1) {
            isLeverOn1 = true;
        }
        if (isLeverOn2) {
            isLeverOn2 = true;
        }
    }

     public void toggleLamp() {
        isLeverOn1 = !isLeverOn1;
        isLeverOn2 = !isLeverOn2;
            if (isLeverOn1 && isLeverOn2){
                gameObject.SetActive(false);
            } else{
                leverOnSignal();
        }
    }
}
