using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_2 : MonoBehaviour 
{
    public Transform Lever3;
    public GameObject lever3;
    public bool isLeverOn2 = true;
    private bool IsCharacterInside = false;
    
    void Start(){
        Lever3.GetComponent<Transform>();
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
            if(Input.GetKeyDown(KeyCode.E)) { // gebruik de toets 'E' voor lever3
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
