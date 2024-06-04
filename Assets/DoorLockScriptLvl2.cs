using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockScriptLvl2 : MonoBehaviour
{
    void Start() {
        if (StaticData.floatToKeep == "teleporter_2b" || StaticData.floatToKeep == "teleporter_3a" || StaticData.floatToKeep == "teleporter_4a") {
            gameObject.SetActive(false);
        }
    }
}
