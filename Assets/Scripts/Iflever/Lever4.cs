using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class lever4 : MonoBehaviour
{
    [SerializeField] GameObject lever4GameObject;

    [SerializeField] GameObject lampje4;

    [SerializeField] GameObject COSprite;


    [SerializeField] private GameObject doorGameObject;
    private IDoor door;

    void Start()
    {
        COSprite.SetActive(false);
    }
    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private bool isKeyPressed = false;

    private bool isCharacterInside = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<MovementScript>() != null)
        {
            isCharacterInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<MovementScript>() != null)
        {
            isCharacterInside = false;
        }
    }

    void Update()
    {
        if (isCharacterInside == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isKeyPressed = !isKeyPressed;
                lever4GameObject.transform.Rotate(0, 180, 180);
                if (isKeyPressed == true)
                {
                    lampje4.gameObject.SetActive(false);
                    door.DoorSignal4();
                }

                if (isKeyPressed == false)
                {
                    lampje4.gameObject.SetActive(true);
                    door.DoorSignalClose3();
                }

                if (isKeyPressed == false)
                {
                    COSprite.gameObject.SetActive(false);
                }

                if (isKeyPressed == true)
                {
                    COSprite.gameObject.SetActive(true);
                }
            }
        }
    }
}



