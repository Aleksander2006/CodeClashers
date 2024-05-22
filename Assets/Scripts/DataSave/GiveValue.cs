using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GiveValue : MonoBehaviour
{
    public string theValue;

    void Start() {
        string newValue = StaticData.floatToKeep;
        theValue = newValue;
        StaticData.floatToKeep = theValue;
    }
}
