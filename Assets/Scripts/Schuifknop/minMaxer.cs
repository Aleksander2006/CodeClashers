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

    void Start() {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;
    }

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
            }
        }
    }

    public void posLimitLeft() {
        if(gameObject.transform.position.x < (startPosX - 0.715f)) {
            if(colliding == false) {
                gameObject.transform.position = new Vector3(startPosX - 0.71f, startPosY, -3.24f);
            }
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

    void FixedUpdate() {
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
