using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class TestTriggerButton : MonoBehaviour {

    [SerializeField] private LampSetActive lamp;

    private void Update(){
        if (Input.GetKeyDown(KeyCode.E))
        {
            lamp.OpenSignal();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            lamp.CloseSignal();
        }
    }
}