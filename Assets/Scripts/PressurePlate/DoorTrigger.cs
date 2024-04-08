using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

    //Dit bestand linken met het interface "IDoor"
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;
    private float DoorTimer;

    //IDoor in het gemaakte object zetten zodat het gelinkt is
    private void Awake() {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void Update() {
        //De timer elke hoeveelheid frames af laten lopen, als hij boven 0 is, is hij bij nul sluit de deur
        if (DoorTimer > 0){
            DoorTimer -= Time.deltaTime;
            if (DoorTimer <= 0f){
                door.CloseDoor();
            }
        }
    }

    //Als de trigger getriggerd word door een collider met "MovementScript" gaat de deur open
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<MovementScript>() != null){
            door.DoorSignal2(); 
        }
    }

    //Als de collider uit de triggerzone loopt gaat het signaal van de PressuerPlate naar de deur uit
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.GetComponent<MovementScript>() !=null)
            door.DoorSignalClose2();
    }

    //Als de collider met "MovementScript" in de triggerzone blijft staan blijft de deur open en houd hij de timer op 1f
    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.GetComponent<MovementScript>() != null)
            DoorTimer = 1f;
    }
}