using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour{

    [SerializeField] private GameObject doorGameObject;
    private IDoor door;
    private float DoorTimer;

    private void Awake(){
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void Update()
    {
        if (DoorTimer > 0)
        {
            DoorTimer -= Time.deltaTime;
            if (DoorTimer <= 0f)
            {
                door.CloseDoor();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<MovementScript>() != null)
        {
            door.OpenDoor();
            
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<MovementScript>() != null)
            DoorTimer = 0.1f;
    }
}