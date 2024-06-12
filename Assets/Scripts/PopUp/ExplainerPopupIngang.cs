using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplainerPopupIngang : MonoBehaviour
{
    public GameObject[] notificationPanels;
    private bool inTriggerZone = false;
    private int currentPanelIndex = 0;
    [SerializeField] GameObject Go;
    [SerializeField] GameObject IngangTrigger;
    private bool firstPopup = false;
    public bool popup = true;

    private void Start()
    {
        if(inTriggerZone == true){
            ShowPopup(currentPanelIndex);
            Go.SetActive(false);
            firstPopup = true;
        }
        
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
                    IngangTrigger.SetActive(false);
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

        if (firstPopup == true) {
            ShowPopup(0);
            firstPopup = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Character"))
        {
            inTriggerZone = false;
            ClosePopup();
            IngangTrigger.SetActive(false);
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
        currentPanelIndex = 0; // Reset currentPanelIndex to zero
        foreach (GameObject panel in notificationPanels)
        {
            panel.SetActive(false);
            popup = false;
        }
    }

    // public void OnTriggerExit2D(){
    //     IngangTrigger.SetActive(false);
    // }
}
