using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScaleRef : MonoBehaviour {
    [SerializeField] GameObject waterGo;
    [SerializeField] 

    public float waterScale;
    public float waterScaleOld;
    public float refColliderScale;
    

    void Start() {
        // waterScaleOld = waterGo.transform.localScale;
    }

    void Update() {
        if(waterScale < waterScaleOld) {

        }
    }
}
