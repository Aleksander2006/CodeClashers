using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour {

    //Dit bestand linken met het interface "IDoor"
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;

    //IDoor in het gemaakte object zetten zodat het gelinkt is
    private void Woke() {
        door = doorGameObject.GetComponent<IDoor>();
    }
    
    //Dit bestand linken met het interface "IPressureplate"
    [SerializeField] private GameObject lampGameObject;
    private IPressurePlate lamp;
    private float timer;

    //IPressureplate in het gemaakte object zetten zodat het gelinkt is
    private void Awake() {
        lamp = lampGameObject.GetComponent<IPressurePlate>();
    }
    
    private void Update() {
        //De timer elke hoeveelheid frames af laten lopen, als hij boven 0 is, timer op 0 is lampje uit
        if (timer > 0){
            timer -= Time.deltaTime;
            if (timer <= 0f){
                lamp.CloseSignal();
            }
        }
    }

    //Als de trigger getriggerd word door een collider met "MovementScript" gaat de lamp aan
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<MovementScript>() != null){
            lamp.OpenSignal();
        }
    }

    //Als de collider met "MovementScript" in de triggerzone blijft staan blijft de lamp aan en houd hij de timer op 1f
    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.GetComponent<MovementScript>() != null){
            timer = 1f;
        }
    }
}