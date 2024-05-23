using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetValue : MonoBehaviour
{
    public string theValue = "#";

    void OnTriggerEnter2D() {
        theValue = gameObject.name;
        Debug.Log(theValue);
        LoadSceneAndKeepValue();
    }
        
    private void LoadSceneAndKeepValue() {
        string savedFloat = theValue;
        StaticData.floatToKeep = savedFloat;
    }
}
