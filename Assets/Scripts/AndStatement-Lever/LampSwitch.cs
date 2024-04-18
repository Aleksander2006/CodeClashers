using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour, Ilamp {

    private bool isLeverOn1 = false;
    
    private bool isLeverOn2 = false;

    public void leverOnSignal1() {
        if (isLeverOn1 == false) {
            isLeverOn1 = true;
            Debug.Log("Lever1 = TRUE");
        }
    }

    public void leverOnSignal2() {
        if (isLeverOn2 == false) {
            isLeverOn2 = true;
            Debug.Log("Lever2 = TRUE");
        }
    }

    public void leverOffSignal1() {
        
        if (isLeverOn1 == true) {
            isLeverOn1 = false;
            Debug.Log("Lever1 = FALSE");
        }
        gameObject.SetActive(true);
    }

    public void leverOffSignal2() {
        
        if (isLeverOn2 == true) {
            isLeverOn2 = false;
            Debug.Log("Lever2 = FALSE");
        }
        gameObject.SetActive(true);
    }

    public void toggleLever1() {
        isLeverOn1 = !isLeverOn1;
        if(!isLeverOn1) {
            leverOnSignal1();  
        }
    }
//in toggle moet nog de isleveron == false (leveroffsignal1&2) opgeroepen worden.
    public void toggleLever2() {
        isLeverOn2 = !isLeverOn2;
        if(!isLeverOn2) {    
            leverOnSignal2();
        }
    }
//toggle moet opgesplitst worden in 1 en 2 om hem TRUE FALSE te maken als je hem nog een keer indrukt, en er moet in update een check zijn oplever on 1 en 2, die als enige de lamp aan kan zetten.
     public void Update() {
            if (isLeverOn1 == true && isLeverOn2 == true){
                gameObject.SetActive(false);
                Debug.Log("lamp AAN");
            }
            if (isLeverOn1 == false || isLeverOn2 == false){
                gameObject.SetActive(true);
                Debug.Log("lamp UIT");
            }
        } 
    }