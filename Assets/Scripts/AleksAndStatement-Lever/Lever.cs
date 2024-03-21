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
    public Transform Lampje1;
    public Transform Lampje2;
    public float zValue = 1f;
    public float zValue2 = -1f; 
    private bool isLeverOn = false;
    private bool IsCharacterInside = false;

    public ScriptReference script;
    
    void Start(){
        Lever1.GetComponent<Transform>();
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
                Debug.Log("Ingedrukt");
                if(isLeverOn) {
                    //Wanneer die uitstaat en aanmoet
                    Debug.Log("Lever 1 staat AAN");
                    
                    transform.localRotation = Quaternion.Euler(0, 180, 180);

                } else {
                    Debug.Log("Lever 1 staat UIT");
                   
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                                
                }
                isLeverOn = !isLeverOn;
                
                if(!isLeverOn){
                    Vector3 newPosition1 = new Vector3(Lampje1.position.x, Lampje1.position.y, zValue);
                    Lampje1.position = newPosition1;
                    
                    Vector3 newPosition2 = new Vector3(Lampje2.position.x, Lampje2.position.y, zValue2);
                    Lampje2.position = newPosition2;

                } else {
                    Vector3 newPosition1 = new Vector3(Lampje1.position.x, Lampje1.position.y, zValue2);
                    Lampje1.position = newPosition1;
                    
                    Vector3 newPosition2 = new Vector3(Lampje2.position.x, Lampje2.position.y, zValue);
                    Lampje2.position = newPosition2;       
                }
            }
        }
    }   
}
