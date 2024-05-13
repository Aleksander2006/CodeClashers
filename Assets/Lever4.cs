using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class lever4 : MonoBehaviour {
    // [SerializeField] GameObject lampOff;

    [SerializeField] GameObject lever4GameObject;

    // private Ilamp lamp;

    private bool isKeyPressed = false;
    
    private bool isCharacterInside = false;

    // private void Awake() {
    //         lamp = lampOff.GetComponent<Ilamp>();
    //     }

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
                lever4GameObject.transform.Rotate(0, 180, 180);
                if (isKeyPressed == true) {
                    Debug.Log("lever4 on");
                }

                if (isKeyPressed == false) {
                    Debug.Log("lever 4 off");
                } 
            }
        }
    }
}



