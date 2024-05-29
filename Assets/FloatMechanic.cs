using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
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
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject MainCharacter;
    [SerializeField] GameObject DupeCharacter;
    private float characterZ;

    void Start()
    {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;

        FloatWaterLayer.transform.localScale = FloatWaterLayer.transform.localScale;
        characterZ = MainCharacter.transform.position.z;
    }

    private void DupeTp() {
        if(characterZ == -2) {
            MainCharacter.GetComponent<SpriteRenderer>().enabled = false;
            MainCharacter.GetComponent<Animator>().enabled = false;
            MainCharacter.GetComponent<MovementScript>().enabled = false;
        }
    }

    void Update() {
        DupeTp();
    }

    public void ScaleLayer()
    { //Check of Schuifknop AANstaat
        if (status == true)
        {
            FloatLayer();
            characterZ = -2;
        }
    }


    private void FloatLayer()
    { // De functie die ervoor zorgt dat de Waterlayer steeds -1 downscaled
        FloatWaterLayer.transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
        if (FloatWaterLayer.transform.localScale.x <= 0f && FloatWaterLayer.transform.localScale.y <= 0f)
        {
            FloatWaterLayer.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    //------------Schuifknop Functionaliteit-------------

    public void posLimiter()
    {
        if (gameObject.transform.position.x > (startPosX + 0.715f) || transform.position.x < (startPosX - 0.715f))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            movable = false;

        }
        else
        {
            if (colliding == true)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                movable = true;
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

    private void OnTriggerStay2D()
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
        if (colliding == true)
        {
            RigidBodyLink.MovePosition(RigidBodyLink.position + movement * MoveSpeed * Time.fixedDeltaTime);
            Debug.Log("Movable...");
        }
        else
        {
            Debug.Log("Not Movable...");
        }
    }
}
