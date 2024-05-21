using System;
using System.Collections;
using System.Collections.Generic;
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

    public float speed = 0;

    //public float endPoint = 10f;

    //[Range(1f, 0f)]
    //public float range;

    [SerializeField] GameObject floatWaterLayer;

    //float [] floatLayer = {0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1f};

    //float [] intLayer = {-1, -2, -3, -4, -5, -6, -7, -8, -9, -10};

    void Start() {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;

        floatWaterLayer.GetComponent<Transform>();
    }
    

    public void ScaleLayer (){
        if (status == true){
            StartCoroutine(FadeDelay());
            IntLayer();
        }
    }

    private IEnumerator FadeDelay() {
        yield return new WaitForSeconds(6);
    }

    public void IntLayer() {
        floatWaterLayer.transform.localScale -= new Vector3(0.7f, 0.7f, 0) * speed;

        if (floatWaterLayer.transform.localScale.x <= 0f && floatWaterLayer.transform.localScale.y <= 0f) {
            floatWaterLayer.transform.localScale = Vector3.zero;
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
            Debug.Log("Movable...");
        } else {
            Debug.Log("Not Movable...");
        }
    } 
}
