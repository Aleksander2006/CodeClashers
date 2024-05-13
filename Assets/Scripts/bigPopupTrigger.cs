using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigPopupTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> popupGameObjects; // Een lijst met de panels
    private int currentPopupIndex = 0; // Index van het huidige panel
    private bool inTriggerZone = false; // Geeft aan of de speler zich in de trigger zone bevindt

    // Huidig panel weergeven
    private void ShowCurrentPopup()
    {
        if (currentPopupIndex < popupGameObjects.Count)
        {
            popupGameObjects[currentPopupIndex].SetActive(true);
        }
    }

    // Huidig panel verbergen
    private void HideCurrentPopup()
    {
        if (currentPopupIndex < popupGameObjects.Count)
        {
            popupGameObjects[currentPopupIndex].SetActive(false);
        }
    }

    // Naar het volgende panel gaan
    private void GoToNextPopup()
    {
        HideCurrentPopup(); // Verberg het huidige panel
        currentPopupIndex++; // Verhoog de index naar het volgende panel
        if (currentPopupIndex < popupGameObjects.Count)
        {
            ShowCurrentPopup(); // Toon het nieuwe huidige panel
        }
        else
        {
            // Als er geen volgende panel meer is, reset de index naar het begin
            currentPopupIndex = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D interactCollider)
    {
        if (interactCollider.GetComponent<MovementScript>() != null)
        {
            // Geeft aan dat de speler zich in de trigger zone bevindt
            inTriggerZone = true;
            // Toon alle pop-ups onmiddellijk
            foreach (var popup in popupGameObjects)
            {
                popup.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D interactCollider)
    {
        if (interactCollider.GetComponent<MovementScript>() != null)
        {
            // Geeft aan dat de speler de trigger zone heeft verlaten
            inTriggerZone = false;
            // Verberg het huidige panel wanneer de speler de trigger verlaat
            HideCurrentPopup();
        }
    }

    private void OnTriggerStay2D(Collider2D interactCollider)
    {
        // Controleer of de speler in de trigger zone is en op de "e"-toets drukt
        if (inTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            // Als het huidige panel niet actief is, toon het
            if (!popupGameObjects[currentPopupIndex].activeSelf)
            {
                ShowCurrentPopup();
            }
            // Als het huidige panel actief is, ga naar het volgende panel
            else
            {
                GoToNextPopup();
            }
        }
    }

    private void Start()
    {
        // Verberg alle panelen bij aanvang van het spel
        foreach (var popup in popupGameObjects)
        {
            popup.SetActive(false);
        }
    }
}
