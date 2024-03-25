using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class Lever : MonoBehaviour
{
    public Transform Lever1;
    
    public Transform Lever2;

    public Transform Lampje1;
    public Transform Lampje2;

    //Hendel weg- UIT
    public float zValue = 1f;
    //Hendel komt-AAN
    public float zValue2 = -1f;

    private bool isLeverOn = false;
    private bool IsCharacterInside = false;
    

    void Start(){
        Lever1.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character") {
            Debug.Log("Inside");
            IsCharacterInside = true;
        } else {
            IsCharacterInside = false;
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
            Debug.Log("Character is binnnen");
            if(Input.GetKeyDown(KeyCode.E)) { // gebruik de toets 'E' voor lever1
                Debug.Log("Ingedrukt");
                if(!isLeverOn) {
                    Debug.Log("Lever 1 staat AAN");
                    lever1.transform.localRotation = Quaternion.Euler(0, 180, 180);
                } else {
                    Debug.Log("Lever 3-4 Hij staat Uit");
                   
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                                
                }

                isLeverOn = !isLeverOn;
            }

            if(Input.GetKeyDown(KeyCode.F)) { // gebruik de toets 'F' voor lever3
                if(!isLeverOn2) {
                    Debug.Log("Lever 2 staat AAN");
                    lever3.transform.localRotation = Quaternion.Euler(0, 180, 180);
                } else {
                    Debug.Log("Lever 2 staat UIT");
                    lever3.transform.localRotation = Quaternion.Euler(0, 0, 0);             
                }
                isLeverOn2 = !isLeverOn2;
            }
            
            //beide levers moeten aanstaan om het lampje te laten branden
            if(!isLeverOn && !isLeverOn2){
                //Grijs lampje gaat weg,
                Lampje1.SetActive(false);
                Debug.Log("Lamp AAN");

            } else { 
                //Grijs lampje blijf
                Lampje1.SetActive(true);
                Debug.Log("Lamp UIT");      
            }  
        } else {
            Debug.Log("Character is BUITEN");
            IsCharacterInside = false;
        }
    }   
}
