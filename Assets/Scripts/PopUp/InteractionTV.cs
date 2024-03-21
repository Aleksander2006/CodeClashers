using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class InteractionTV : MonoBehaviour
{
    public GameObject notification;
    public Button closeButton;

    private bool inTriggerZone = false;

    private void Start()
    {
        notification.SetActive(false);
        closeButton.onClick.AddListener(ClosePopup);
    }

    private void Update()
    {
        // Controleer of de speler in de triggerzone is en de linker muisknop indrukt
        if (inTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            if (notification.activeSelf)
            {
                ClosePopup();
            }
            else
            {
                OpenPopup();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Controleer of de speler de triggerzone betreedt
        if (collision.CompareTag("Character"))
        {
            inTriggerZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Controleer of de speler de triggerzone verlaat
        if (collision.CompareTag("Character"))
        {
            inTriggerZone = false;
            ClosePopup(); // Sluit de popup als de speler de triggerzone verlaat
        }
    }

    private void OpenPopup()
    {
        notification.SetActive(true);
    }
    private void ClosePopup()
    {
        if (notification != null) // Controleer of het GameObject geldig is voordat je het probeert te deactiveren
        {
            notification.SetActive(false);
        }
    }
}
