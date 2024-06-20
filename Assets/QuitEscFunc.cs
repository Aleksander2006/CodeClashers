using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuitEscFunc : MonoBehaviour {
    public void ExitGame(){
        Application.Quit();
        Debug.Log("Exit");
    }
}
