using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockLevel2Inside : MonoBehaviour {
    [SerializeField] Boolbutton BoolScript;

    void Update() {
        if(BoolScript.LayerAan == false) {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
