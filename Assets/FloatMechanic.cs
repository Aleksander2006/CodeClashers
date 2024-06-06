using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.TextCore.Text;

public class LegeSchuifknopScript : MonoBehaviour
{
    private bool movable = false;
    private bool colliding = false;
    public float MoveSpeed = 5f;
    public Rigidbody2D RigidBodyLink;
    private float startPosX = 0;
    private float startPosY = 0;
    Vector2 movement;
    public bool status = false;
    [SerializeField] GameObject FloatWaterLayer;
    [SerializeField] BoxCollider2D waterLevel;
    [SerializeField] GameObject WaterpeilFloatLayer;
    [SerializeField] float speed = 0.2f;

    void Start()
    {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;
        FloatWaterLayer.transform.localScale = FloatWaterLayer.transform.localScale;
        WaterpeilFloatLayer.transform.localScale = WaterpeilFloatLayer.transform.localScale;
    }

    public void ScaleLayer()
    { //Check of Schuifknop AANstaat
        if (status == true)
        {
            FloatLayer();
        }
    }

    private void FloatLayer()
    { // De functie die ervoor zorgt dat de Waterlayer steeds -1 downscaled
        FloatWaterLayer.transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
        waterLevel.size -= new Vector2(0.009f, 0.009f);
        if (FloatWaterLayer.transform.localScale.x <= 0f && FloatWaterLayer.transform.localScale.y <= 0f)
        {
            FloatWaterLayer.transform.localScale = new Vector3(0, 0, 0);
            waterLevel.size = new Vector2(0,0);
        }

        WaterpeilFloatLayer.transform.localScale -= new Vector3(0.05f, 0f, 0f) * speed;
        if (WaterpeilFloatLayer.transform.localScale.x <= 0f)
        {
            WaterpeilFloatLayer.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    //------------Schuifknop Functionaliteit-------------//

    private void MoveLeft() {
        if (colliding == false && gameObject.transform.position.x > startPosX) {
            gameObject.transform.position -= new Vector3(0.025f, 0, 0);
        }
    }

    private void MoveRight() {
        if (colliding == false && gameObject.transform.position.x < startPosX) {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.025f, 0, 0);
        }
    }

    public void posLimiter()
    {
        if (gameObject.transform.position.x > (startPosX + 0.715f) || transform.position.x < (startPosX - 0.715f))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }
        else
        {
            if (colliding == true)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    public void posLimitRight()
    {
        if (gameObject.transform.position.x > (startPosX + 0.715f))
        {
            if (colliding == false)
            {
                gameObject.transform.position = new Vector3(startPosX + 0.71f, startPosY, -3.24f);
            }
            status = true;
        }
    }

    public void posLimitLeft()
    {
        if (gameObject.transform.position.x < (startPosX - 0.715f))
        {
            if (colliding == false)
            {
                gameObject.transform.position = new Vector3(startPosX - 0.71f, startPosY, -3.24f);
            }
            status = false;
        }
    }

    private void OnTriggerEnter2D()
    {
        colliding = true;
    }

    private void OnTriggerExit2D()
    {
        colliding = false;
    }

    void FixedUpdate()
    {
        ScaleLayer();
        posLimiter();
        posLimitRight();
        posLimitLeft();
        MoveLeft();
        MoveRight();

        if (colliding == true)
        {
            RigidBodyLink.MovePosition(RigidBodyLink.position + movement * MoveSpeed * Time.fixedDeltaTime);        
        }
    }
}
