using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_2 : MonoBehaviour 
{
    public GameObject lever3;
    public bool isLeverOn2 = true;
    private bool IsCharacterInside = false;

    void Start(){
        lever3.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character") {
            Debug.Log("Inside");
            IsCharacterInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Character") {
            Debug.Log("Outside");
            IsCharacterInside = false;
        }
    }

    void Update() {
        if (IsCharacterInside){
            if(Input.GetKeyDown(KeyCode.E)) { // gebruik de toets 'E' voor lever3
                Debug.Log("E key pressed");
                if(!isLeverOn2) {
                    Debug.Log("Lever 2 staat UIT");
                    lever3.transform.localRotation = Quaternion.Euler(0, 180, 180);
                    isLeverOn2 = false;
                } else {
                    Debug.Log("Lever 2 staat AAN");
                    lever3.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    isLeverOn2 = true;
                }
                isLeverOn2 = !isLeverOn2;
            }
        }
    }
}