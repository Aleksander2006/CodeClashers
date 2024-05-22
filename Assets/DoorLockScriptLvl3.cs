using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockScriptLvl3 : MonoBehaviour
{
    void Start() {
        if (StaticData.floatToKeep == "teleporter_4a") {
            gameObject.SetActive(false);
            Debug.Log("Nu is ie uit");
        }
    }

    void Update() {
        Debug.Log("Nu is ie aan");
    }
}
