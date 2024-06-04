using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LiveWaterscaleScript : MonoBehaviour {
    [SerializeField] BoxCollider2D waterLevel;
    [SerializeField] TextMeshProUGUI scalePrinter;
    private float scaleWaterX;
    private float scaleWaterY;

    private string levelSizeX;
    private string levelSizeY;

    void Start() {
        
    }

    void Update() {
        waterLevel.size = new Vector2(scaleWaterX, scaleWaterY);
        scaleWaterX = waterLevel.size.x;
        scaleWaterY = waterLevel.size.y;
        

        string levelSizeX = scaleWaterX.ToString();

        scalePrinter.text = levelSizeX;

        Debug.Log(levelSizeX);
        //gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = scaleWater.size;//waterLayerFloat.transform.localScale;
    }
}


//nog doen:
//de waterlevel.size.x en y converten naar een string en onderin de update zetten achter scaleprinter.text = "DAN HIER DE GECONVERTE STRING" 