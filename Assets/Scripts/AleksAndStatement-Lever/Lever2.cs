using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public Transform Lever3;
    public Transform Lampje1;
    public Transform Lampje2;

    private bool isLeverOn = false;
    private bool IsCharacterInside = false;
    
    void Start(){
        Lever3.GetComponent<Transform>();
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
            if(Input.GetKeyDown(KeyCode.E)) { 
                Debug.Log("INgedrukt");
                if(isLeverOn) {
                    //Wanneer die uitstaat en aanmoet
                    Debug.Log("Lever 3-4 Hij staat Aan");

                    transform.localRotation = Quaternion.Euler(0, 180, 180);
                    
                } else {
                    Debug.Log("Lever 3-4 Hij staat Uit");

                    transform.localRotation = Quaternion.Euler(0, 0, 0);             
                }

                isLeverOn = !isLeverOn;
            }
        }
    }   
}
