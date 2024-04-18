using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour, Ilamp {
   [SerializeField] private GameObject doorGameObject;
    private IDoor door;
    private void Awake() {
        door = doorGameObject.GetComponent<IDoor>();
    }

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

     public void Update() {
            if (isLeverOn1 == true && isLeverOn2 == true){
                gameObject.SetActive(false);
                door.DoorSignal1();
                Debug.Log("lamp AAN");
            }
            if (isLeverOn1 == false || isLeverOn2 == false){
                gameObject.SetActive(true);
                Debug.Log("lamp UIT");
                door.DoorSignalClose1();
            }
        } 
    }