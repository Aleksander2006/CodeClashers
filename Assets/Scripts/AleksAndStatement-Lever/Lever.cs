using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class Lever : MonoBehaviour
{
//private GameObject Lampje1;
//private GameObject Lever2;
//private GameObject Lever4;

//public SpriteRenderer Lever1;
//public SpriteRenderer Lever2;
//public SpriteRenderer Lever3;
//public SpriteRenderer Lever4;
//public SpriteRenderer Lampje1;
//public SpriteRenderer Lampje2;

    public GameObject Object;
    public Transform Lever1;
    public Transform Lever2;

//Hendel weg- UIT
    public float zValue = 1f;
//Hendel komt-AAN
    public float zValue2 = -1f;

    private bool isLeverOn = false;

    void Start()
    {
      Lever1.GetComponent<Transform>();
      Lever2.GetComponent<Transform>();
      //Lever3.GetComponent<Transform>();
      //Lever4.GetComponent<Transform>();
      
      //Lampje1.GetComponent<Transform>();
      //Lampje2.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

// private void OnTriggerEnter2D(Collider2D other) {
     // if(other.tag == "Character") {
     //     
     // } 

 //

//if (Gameobject = true && Gameobject = true){
 
//}

 if (Input.GetKeyDown(KeyCode.E)){

    if(isLeverOn)
    {
    //Wanneer die uitstaat en aanmoet
            Vector3 newPosition1 = new Vector3(Lever1.position.x, Lever1.position.y, zValue);
            Lever1.position = newPosition1;

            Vector3 newPosition2 = new Vector3(Lever2.position.x, Lever2.position.y, zValue2);
            Lever2.position = newPosition2; 
    }
    //Wanneer die uit aan staat en uit moet
    else {
            Vector3 newPosition1 = new Vector3(Lever1.position.x, Lever1.position.y, zValue2);
            Lever1.position = newPosition1;

            Vector3 newPosition2 = new Vector3(Lever2.position.x, Lever2.position.y, zValue);
            Lever2.position = newPosition2; 
    }

    }

    isLeverOn = !isLeverOn;
               
    }


}