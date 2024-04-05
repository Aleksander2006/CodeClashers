using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_1 : MonoBehaviour
{
    public Transform Lever1;
    public GameObject lever1; 
    public bool isLeverOn = true;

    private bool IsCharacterInside = false;
    
    void Start(){
        Lever1.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character") {
            //Debug.Log("Inside");
            IsCharacterInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Character") {
            //Debug.Log("Outside");
            IsCharacterInside = false;
        }
    }
            
    void Update() {
        if (IsCharacterInside){
            //Debug.Log("Character is binnnen");
            if(Input.GetKeyDown(KeyCode.E)) { // gebruik de toets 'E' voor lever1
                Debug.Log("E key pressed");
                if(!isLeverOn) {
                    Debug.Log("Lever 1 staat UIT");
                    lever1.transform.localRotation = Quaternion.Euler(0, 180, 180);
                    isLeverOn = false;
                } else {
                    Debug.Log("Lever 1 staat AAN");
                    lever1.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    isLeverOn = true;   
                }
                isLeverOn = !isLeverOn;
            }  
        }  
    }
}
