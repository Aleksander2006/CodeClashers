using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lever2 : MonoBehaviour {
    [SerializeField] GameObject lampOff;    
    private Ilamp lamp;


    
    private bool isCharacterInside = false;

    private void OnTriggerEnter2D(Collider2D collider) {
            if (collider.GetComponent<MovementScript>() != null) {
                isCharacterInside = true;
            }
    }
   private void OnTriggerExit2D(Collider2D collider) {
            if (collider.GetComponent<MovementScript>() != null) {
                isCharacterInside = false;
            }
    }

    private void Awake() {
        lamp = lampOff.GetComponent<Ilamp>();
    }
    void Update() {
        if (isCharacterInside == true) {
            if (Input.GetKeyDown(KeyCode.E)) {
                lamp.toggleLamp();
            }
        }
    }
}
