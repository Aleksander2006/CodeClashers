using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_4 : MonoBehaviour
{
    public Transform Lever4;
    public GameObject lever4;
    public bool isLeverOn4 = false; // Start met de hendel uitgeschakeld
    private bool IsCharacterInside = false;

    void Start()
    {
        Lever4.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            IsCharacterInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            IsCharacterInside = false;
        }
    }

    void Update()
    {
        if (IsCharacterInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { // Gebruik de toets 'E' voor lever4
                isLeverOn4 = !isLeverOn4; // Wissel de status van de hendel
                UpdateLeverRotation(); // Roep een functie aan om de rotatie van de hendel bij te werken
            }
        }
    }

    void UpdateLeverRotation()
    {
        if (isLeverOn4)
        {
            lever4.transform.localRotation = Quaternion.Euler(0, 180, 180);
            Debug.Log("Lever 4 staat AAN");
        }
        else
        {
            lever4.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Lever 4 staat UIT");
        }
    }
}

