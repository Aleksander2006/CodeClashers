using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
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
    private float counter = 7.842517f;
    private float counter2 = 6.596645f;
    private float timer = 0;
    private float delay = 0.8f; // 0,8 seconden vertraging elke Layer

    [SerializeField] GameObject IntWaterLayer;

    void Start() {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;

        IntWaterLayer.GetComponent<Transform>();
    }

    public void ScaleLayer (){ //Check of Schuifknop AANstaat
        if (status == true){
            StartCoroutine(FadeDelay());
        }
    }

    private IEnumerator FadeDelay() { //Zorgt ervoor dat de Schuifknop wacht voor 0,7 seconden en dan doorgaat.
        yield return new WaitForSeconds(0.7f);
        IntLayer();
    }

    private void IntLayer() { // De functie die ervoor zorgt dat de Waterlayer steeds -1 downscaled
        if (timer > delay) {
            timer = 0f;
            if (counter >= 1) {
                IntWaterLayer.transform.localScale = transform.TransformVector(counter, counter2, 0) - new Vector3(0.842517f, 0.596645f, 0);
                counter--;
                counter2--;
            }
        }
    }

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
