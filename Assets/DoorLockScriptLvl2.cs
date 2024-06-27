using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLockScriptLvl2 : MonoBehaviour
{
    void Start() {
        if (StaticData.lvl1Completed == true) {
            gameObject.SetActive(false);
        }
    }
}
