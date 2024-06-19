using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PauzeMenuScript : MonoBehaviour {
    
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject pauzeMenu;
    private static bool escPressed = false;
    [SerializeField] GameObject dontDestroyGo;
    [SerializeField] GameObject dontDestroyGo2;
    [SerializeField] GameObject dontDestroyGo3;

    void Start() {
        // DontDestroyOnLoad(pauzeMenu);
        // DontDestroyOnLoad(dontDestroyGo);
        // DontDestroyOnLoad(dontDestroyGo2);
    }


    private void EscToggle() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            escPressed = !escPressed;
        } 
    }

    private void Pauzer() {
        if(escPressed == true) {
            Time.timeScale = 0f;
            mainCharacter.GetComponent<Animator>().enabled = false;
        }
    }

    private void Resumer() {
        if(escPressed == false) {
            Time.timeScale = 1f;
            mainCharacter.GetComponent<Animator>().enabled = true;
        }
    }

    private void MenuToggle() {
        if(escPressed == false) {
            pauzeMenu.SetActive(false);
        }

        if(escPressed == true) {
            pauzeMenu.SetActive(true);
        }
    }


    void Update() {
        EscToggle();
        Pauzer();
        Resumer();
        MenuToggle();
        Debug.Log("EscPressed is " + escPressed);
    }
}


/// misschien kan ik wel een scene maken met een gO die dit soort functies in een interface hebben staan, waar je dan bij kan, en dus dit kan uitvoeren in welke scene dan ook, deze scene moet je dan niet kunnen uitzetten, deze moet altijd aan zijn... zegamaar een menu toggler.