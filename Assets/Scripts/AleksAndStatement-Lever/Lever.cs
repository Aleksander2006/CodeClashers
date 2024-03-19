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

public SpriteRenderer Lever1;
public SpriteRenderer Lever2;
public SpriteRenderer Lever3;
public SpriteRenderer Lever4;
public SpriteRenderer Lampje1;
public SpriteRenderer Lampje2;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey("e")){
        Lampje1.enabled = false;
        Lampje2.enabled = true;
        }  
    }




}

//if (Lever2.GetComponent<Transform>()){
        //    
        //}
//
        //if (Lever4.GetComponent<Transform>()){
        //    
        //}
//
//
        //if (Lever2.GetComponent<Transform>() && Lever4.GetComponent<Transform>()) {
        //    
        //Lampje1.GetComponent<Transform>();
        //}
        //else
        //{
    //
        //}
