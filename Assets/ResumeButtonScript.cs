using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResumeButtonScript : MonoBehaviour {

    [SerializeField] PauzeMenuScript pauzeMenuScript;

    public void ResumeButtonFunc() {
        pauzeMenuScript.ResumeButtonFunction(); 
    }
}
