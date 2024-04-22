using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTV : MonoBehaviour
{
    public GameObject[] notificationPanels;
    public Button closeButton;
    private bool inTriggerZone = false;
    private int currentPanelIndex = 0;

    private void Start()
    {
        ShowPopup(currentPanelIndex);
        closeButton.onClick.AddListener(ClosePopup);
    }

    private void Update()
    {
        if (inTriggerZone && Input.GetKeyDown(KeyCode.E))
        {
            if (notificationPanels[currentPanelIndex].activeSelf)
            {
                if (currentPanelIndex < notificationPanels.Length - 1)
                {
                    currentPanelIndex++;
                    ShowPopup(currentPanelIndex);
                }
                else
                {
                    ClosePopup();
                }
            }
            else
            {
                ShowPopup(currentPanelIndex);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            inTriggerZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            inTriggerZone = false;
            ClosePopup();
        }
    }

    private void ShowPopup(int index)
    {
        foreach (GameObject panel in notificationPanels)
        {
            panel.SetActive(false);
        }

        notificationPanels[index].SetActive(true);
    }

    private void ClosePopup()
    {
        currentPanelIndex = 0; // Reset currentPanelIndex naar nul
        foreach (GameObject panel in notificationPanels)
        {
            panel.SetActive(false);
        }
    }
}

