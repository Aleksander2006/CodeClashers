using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour{

    [SerializeField] private GameObject lampGameObject;
    private IPressurePlate lamp;
    private float timer;

    private void Awake(){
        lamp = lampGameObject.GetComponent<IPressurePlate>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                lamp.CloseSignal();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<MovementScript>() != null)
        {
            lamp.OpenSignal();
            
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<MovementScript>() != null)
            timer = 0.1f;
    }
}