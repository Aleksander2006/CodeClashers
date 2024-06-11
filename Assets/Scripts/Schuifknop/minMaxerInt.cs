using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.TextCore.Text;

public class minMaxerInt : MonoBehaviour
{
    private bool colliding = false;
    public float MoveSpeed = 5f;
    public Rigidbody2D RigidBodyLink;
    private float startPosX = 0;
    private float startPosY = 0;
    Vector2 movement;

    public bool status = false;
    private float counter = 7.842517f;
    private float counter2 = 6.596645f;

    private float MinGetalX = 1.5685034f;
    private float MinGetalY = 1.319329f;
    private float timer = 0;
    private float delay = 0.8f; // 0,8 seconden vertraging elke Layer

    //Waterpeil
    private float counterWaterpeil = 10f;
    private float MinGetalXWaterpeil = 2f;
    [SerializeField] float speed = 0;

    [SerializeField] float speedStijgen = 0.5f;

    //Check of layer aanstaat
    public bool LayerAan = true;

    public bool EersteKeerAangezet = false;

    public bool AanOpStart = false;

    [SerializeField] GameObject IntWaterLayer;
    [SerializeField] GameObject FloatWaterLayer;
    [SerializeField] GameObject WaterpeilIntLayer;
    [SerializeField] BoxCollider2D waterLevel;

    //Script links met Bool en Float Layer
    [SerializeField] Boolbutton boolbutton;
    [SerializeField] LegeSchuifknopScript floatScipt;

    [SerializeField] GameObject floatLayerGo;
    private bool canMoveBack = false;
    private bool wrongButton = true;
    [SerializeField] GameObject IntSchuif;

    [SerializeField] SpriteRenderer spriteRenderer;
    private bool isRight = false;

    public bool zakken = true;


    void Start()
    {
        startPosX = startPosX + gameObject.transform.position.x;
        startPosY = startPosY + gameObject.transform.position.y;
        
        boolbutton.GetComponent<Boolbutton>();
        floatScipt.GetComponent<LegeSchuifknopScript>();

        spriteRenderer = IntSchuif.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;

        IntWaterLayer.GetComponent<BoxCollider2D>().enabled = false;
    }

    
    public void WaterGrowInt(){ //Zorgt ervoor dat de Intlayer stijgt als de floatlayer weg is
        
        if (zakken == true && FloatWaterLayer.transform.localScale.x <= 0 && FloatWaterLayer.transform.localScale.y <= 0)
        {
               
                IntWaterLayer.transform.localScale += new Vector3(0.1f, 0.01f,0) * speedStijgen;
                zakken = true;

                if(IntWaterLayer.transform.localScale.y >= 7.05f){
                IntWaterLayer.transform.localScale = new Vector3(IntWaterLayer.transform.localScale.x, 7.05f, IntWaterLayer.transform.localScale.z);
                 
                }
                
                if (IntWaterLayer.transform.localScale.x <= 0.1f && IntWaterLayer.transform.localScale.y <= 0.1f){
                    IntWaterLayer.transform.localScale = Vector3.zero;
                }
                
                if (IntWaterLayer.transform.localScale.x >= 18.68f)
                {
                    IntWaterLayer.transform.localScale = new Vector3(18.68f, 7.05f, 0); 
                }                 
            }      
    }


    public void ScaleLayer()
    { //Check of Schuifknop AANstaat
        
        if (AanOpStart == true){
            if (status == true && boolbutton.LayerAan == true && floatScipt.LayerAan == false)
            {
                StartCoroutine(FadeDelay());
                LayerAan = false;
                EersteKeerAangezet = true;

                spriteRenderer.color = Color.green;
            }

            if (EersteKeerAangezet == true){
                spriteRenderer.color = Color.green;
            }
        }       
    }

    private IEnumerator FadeDelay()
    { //Zorgt ervoor dat de Schuifknop wacht voor 0,7 seconden en dan doorgaat.
        yield return new WaitForSeconds(0.7f);
        IntLayer();
    }

    private void IntLayer()
    { // De functie die ervoor zorgt dat de Waterlayer steeds -1 downscaled
        if (timer > delay)
        {
            timer = 0f;
            if (counter >= 1)
            {
                IntWaterLayer.transform.localScale = transform.TransformVector(counter, counter2, 0) - new Vector3(MinGetalX, MinGetalY, 0);
                waterLevel.size = waterLevel.size - new Vector2(0.2f, 0.2f);
                counter -= MinGetalX;
                counter2 -= MinGetalY;

                if (IntWaterLayer.transform.localScale.x <= 0 && IntWaterLayer.transform.localScale.y <= 0){
                    IntWaterLayer.transform.localScale = Vector3.zero;
                }
            }

            if (counterWaterpeil >= 1)
            {
                WaterpeilIntLayer.transform.localScale = transform.TransformVector(counterWaterpeil, 10, 0) - new Vector3(MinGetalXWaterpeil, 0, 0);
                
                counterWaterpeil -= MinGetalXWaterpeil;
                if (WaterpeilIntLayer.transform.localScale.x <= 0){
                    WaterpeilIntLayer.transform.localScale = Vector3.zero;
                }
            }  
        }
    }

    //------------Schuifknop Functionaliteit-------------

    private void MoveLeft() {
        if (colliding == false && gameObject.transform.position.x > startPosX) {
            gameObject.transform.position -= new Vector3(0.025f, 0, 0);
            LayerAan = true;
        }
    }

    private void MoveRight() {
        if (colliding == false && gameObject.transform.position.x < startPosX) {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0.025f, 0, 0);
            LayerAan = true;
        }
    }
    
    public void posLimiter()
    {
        if (gameObject.transform.position.x > (startPosX + 0.715f) || transform.position.x < (startPosX - 0.715f))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            canMoveBack = true;
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
            isRight = true;
            if (colliding == false)
            {
                gameObject.transform.position = new Vector3(startPosX + 0.71f, startPosY, -3.24f);
            }
            
            if(floatScipt.LayerAan == true) {
                status = false;
            }
            if(floatScipt.LayerAan == false) {
                status = true;
            }
            AanOpStart = true;
            zakken = false;
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
        if(floatLayerGo.transform.localScale.x > 0 && isRight == true) {
                spriteRenderer.color = Color.red;
            }

        if(gameObject.transform.position.x < (startPosX + 0.715f)) {
           isRight = false; 
        }

        if(spriteRenderer.color == Color.red || spriteRenderer.color == Color.white) {
                MoveLeft();
                MoveRight();       
        }

        if(floatLayerGo.transform.localScale.x == 0 && status == true) {
            ScaleLayer();
            status = true;
        }

        if(floatScipt.LayerAan == false) {
            IntWaterLayer.GetComponent<BoxCollider2D>().enabled = true;
        }
        
    
        WaterGrowInt(); 
        posLimiter();
        posLimitRight();
        posLimitLeft();
        if (colliding == true)
        {
            RigidBodyLink.MovePosition(RigidBodyLink.position + movement * MoveSpeed * Time.fixedDeltaTime);
            //Debug.Log("Movable...");
        }
        else
        {
            //Debug.Log("Not Movable...");
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
    }
}
