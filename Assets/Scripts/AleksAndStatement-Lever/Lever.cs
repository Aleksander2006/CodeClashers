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
                    Debug.Log("Lever 1 staat AAN");
                    
                    transform.localRotation = Quaternion.Euler(0, 180, 180);

                } else {
                    Debug.Log("Lever 1 staat UIT");
                   
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                                
                }
                isLeverOn = !isLeverOn;
                
                     
                }
            }
        }
    }   

