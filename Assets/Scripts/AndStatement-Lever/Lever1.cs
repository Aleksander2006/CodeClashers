using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lever1 : MonoBehaviour {
    [SerializeField] GameObject lampOff;

    [SerializeField] GameObject lever1GameObject;

    private Ilamp lamp;

    private bool isKeyPressed = false;
    
    private bool isCharacterInside = false;

    private void Awake() {
            lamp = lampOff.GetComponent<Ilamp>();
        }

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

    void Update() {
        if (isCharacterInside == true) {
            if (Input.GetKeyDown(KeyCode.E)) {
                isKeyPressed = !isKeyPressed;
                lever1GameObject.transform.Rotate(0, 180, 180);
                if (isKeyPressed == true) {
                    lamp.leverOnSignal1();
                }

                if (isKeyPressed == false) {
                    lamp.leverOffSignal1();
                } 
            }
        }
    }
}



