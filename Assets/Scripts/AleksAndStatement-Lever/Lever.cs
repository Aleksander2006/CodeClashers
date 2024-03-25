using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;
    private void Woke(){
        door = doorGameObject.GetComponent<IDoor>();
    }
    private bool isLampOn1 = false;
    private bool isLampOn2 = false;
    public Transform Lever1;
    public Transform Lever3;

    public GameObject lever1;
    public GameObject lever3;

    public GameObject Lampje1;
    public GameObject Lampje2;
    private bool isLeverOn = true;
    private bool isLeverOn2 = true;
    private bool IsCharacterInside = false;
    
    void Start(){
        Lever1.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character") {
            Debug.Log("Inside");
            IsCharacterInside = true;
        }
    }

    //void OnTriggerExit2D(Collider2D other) {
    //    if(other.tag == "Character") {
    //        Debug.Log("Outside");
    //        IsCharacterInside = false;
    //    }
    //}
            
    void Update() {
        if (IsCharacterInside){
            if(Input.GetKeyDown(KeyCode.E)) { // gebruik de toets 'E' voor lever1
                Debug.Log("Ingedrukt");
                if(!isLeverOn) {
                    Debug.Log("Lever 1 staat AAN");
                    lever1.transform.localRotation = Quaternion.Euler(0, 180, 180);
                } else {
                    Debug.Log("Lever 1 staat UIT");
                    lever1.transform.localRotation = Quaternion.Euler(0, 0, 0);   
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
                isLampOn1 = true;

            } else { 
                //Grijs lampje blijf
                Lampje1.SetActive(true);
                Debug.Log("Lamp UIT");
                isLampOn1 = false;
            }  
        }
    }

    public void SignalLamp1() {
        isLampOn1 = !isLampOn1;
        if (!isLampOn1) {
            door.DoorSignal1();
        } 
    } 

    public void SignalLamp2() {
        isLampOn2 =!isLampOn2;
        if (!isLampOn2) {
            door.DoorSignal2();
        }
    }
}