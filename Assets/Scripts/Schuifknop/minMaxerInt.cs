using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.TextCore.Text;

public class minMaxer : MonoBehaviour 
{
    private bool movable = false;
    private bool colliding = false;
    public float MoveSpeed = 5f;
    public Rigidbody2D RigidBodyLink;
    private float startPosX = 0;
    private float startPosY = 0;
    Vector2 movement;

    public bool status = false;
    //public float speed = 0.012f;

    private int counter = 10;
    private float timer = 0;
    private float delay = 0.5f; // 0,5 seconde vertraging

    [SerializeField] GameObject floatWaterLayer;

    void Start() {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;

        floatWaterLayer.GetComponent<Transform>();
    }

    public void ScaleLayer (){ //Check of Schuifknop AANstaat
        if (status == true){
            StartCoroutine(FadeDelay());
        }
    }

    private IEnumerator FadeDelay() {
        yield return new WaitForSeconds(0.5f);
        IntLayer();
    }

    private void IntLayer() {
        if (timer > delay) {
            timer = 0f;
            if (counter >= 1) {
                floatWaterLayer.transform.localScale = transform.TransformVector(counter, counter, counter) - new Vector3(1, 1, 0);
                counter--;
            }
        }
    }


    

    // private void IntLayer() { //Zorgt ervoor dat de WaterLayer kleiner wordt
    //     floatWaterLayer.transform.localScale = transform.TransformVector(10, 10, 10) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());
        
    //     floatWaterLayer.transform.localScale = transform.TransformVector(9, 9, 9) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());
        
    //     floatWaterLayer.transform.localScale = transform.TransformVector(8, 8, 8) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     floatWaterLayer.transform.localScale = transform.TransformVector(7, 7, 7) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     floatWaterLayer.transform.localScale = transform.TransformVector(6, 6, 6) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     floatWaterLayer.transform.localScale = transform.TransformVector(5, 5, 5) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     floatWaterLayer.transform.localScale = transform.TransformVector(4, 4, 4) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     floatWaterLayer.transform.localScale = transform.TransformVector(3, 3, 3) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     floatWaterLayer.transform.localScale = transform.TransformVector(2, 2, 2) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     floatWaterLayer.transform.localScale = transform.TransformVector(1, 1, 1) - new Vector3(1, 1, 0);
    //     StartCoroutine(FadeDelay2());

    //     // if (floatWaterLayer.transform.localScale.x <= 0 && floatWaterLayer.transform.localScale.y <= 0) {
    //     //     floatWaterLayer.transform.localScale = Vector2.zero;
    //     // }
    // }

    //------------Schuifknop Functionaliteit-------------

    public void posLimiter() {
        if(gameObject.transform.position.x > (startPosX + 0.715f) || transform.position.x < (startPosX - 0.715f)) {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            movable = false;
            
        } else {
            if(colliding == true){
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            movable = true;
            }
        }
    }

    public void posLimitRight() {
        if(gameObject.transform.position.x > (startPosX + 0.715f)) {
            if(colliding == false) {
                gameObject.transform.position = new Vector3(startPosX + 0.71f, startPosY, -3.24f);
            } status = true;
        }
    }

    public void posLimitLeft() {
        if(gameObject.transform.position.x < (startPosX - 0.715f)) {
            if(colliding == false) {
                gameObject.transform.position = new Vector3(startPosX - 0.71f, startPosY, -3.24f);
            } status = false;
        }
    }

    private void OnTriggerEnter2D(){
        colliding = true;
    }

    private void OnTriggerStay2D() {
        colliding = true;
    }

    private void OnTriggerExit2D(){
        colliding = false;
    }

    void FixedUpdate(){
       
        ScaleLayer();
        posLimiter();
        posLimitRight();
        posLimitLeft();
        if(colliding == true) {
            RigidBodyLink.MovePosition(RigidBodyLink.position + movement * MoveSpeed * Time.fixedDeltaTime);
            //Debug.Log("Movable...");
        } else {
            //Debug.Log("Not Movable...");
        }
    } 

    void Update (){
        timer += Time.deltaTime;
    }
}
