using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LiveWaterscaleScript : MonoBehaviour {
    [SerializeField] BoxCollider2D waterLevel;
    [SerializeField] TextMeshProUGUI scalePrinter;
    private float scaleWater;
    private string levelSize;

    public float ToSingle(double scaleWater) {
        return (float)scaleWater;
    }

    void FixedUpdate() {
        scaleWater = waterLevel.size.x;
        scaleWater = waterLevel.size.y;

        if(scaleWater == 1){
            scaleWater = 1;
        }

        if(scaleWater < 0.0001) {
            scaleWater = 0;
        }

        if(scaleWater < 1 && scaleWater > 0.0001) {
            scaleWater = (float)Math.Round(scaleWater, 3) + 0.0001f;
        }

        levelSize = scaleWater.ToString();
        scalePrinter.text = levelSize;

    }
} 