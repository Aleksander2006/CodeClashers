using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public GameObject[] popups; // Array met referenties naar de pop-up prefabs
    private int currentPopupIndex = 0; // Index van de huidige pop-up

    private bool inTriggerZone = false;

    void Update()
    {
        // Als de speler in de trigger zone is en op de "E"-toets drukt
        if (inTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextPopup(); // Toon de volgende pop-up
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Als de speler de trigger zone binnengaat
        if (collision.CompareTag("Player"))
        {
            inTriggerZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Als de speler de trigger zone verlaat
        if (collision.CompareTag("Player"))
        {
            inTriggerZone = false;
        }
    }

    private void ShowNextPopup()
    {
        if (currentPopupIndex < popups.Length)
        {
            // Activeer de volgende pop-up als er nog pop-ups zijn
            popups[currentPopupIndex].SetActive(true);
            currentPopupIndex++;
        }
        else
        {
            // Sluit het pop-up scherm als er geen pop-ups meer zijn
            Destroy(gameObject);
        }
    }
}
