using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PauzeMenuScript : MonoBehaviour {
    
    [SerializeField] GameObject mainCharacter;
    [SerializeField] GameObject backGroundAudio;
    [SerializeField] GameObject pauzeMenu;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject quitButton;
    public static bool escPressed = false;
    [SerializeField] GameObject dontDestroyGo;
    [SerializeField] GameObject dontDestroyGo2;
    [SerializeField] GameObject dontDestroyGo3;

    void Start() {
        resumeButton.SetActive(false);
        quitButton.SetActive(false);

        // DontDestroyOnLoad(pauzeMenu);
        // DontDestroyOnLoad(dontDestroyGo);
        // DontDestroyOnLoad(dontDestroyGo2);
    }


    public void EscToggle() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            escPressed = !escPressed;
        } 
    }

    public void ResumeButtonFunction() {
            escPressed = !escPressed;
            mainCharacter.GetComponent<AudioSource>().enabled = true;
            backGroundAudio.GetComponent<AudioSource>().Play();
    }

    private void Pauzer() {
        if(escPressed == true) {
            Time.timeScale = 0f;
            mainCharacter.GetComponent<Animator>().enabled = false;
            if(Input.GetKeyDown(KeyCode.Escape)) {
            mainCharacter.GetComponent<AudioSource>().enabled = false;
            backGroundAudio.GetComponent<AudioSource>().Pause();
            }
        }
    }

    private void Resumer() {
        if(escPressed == false) {
            Time.timeScale = 1f;
            mainCharacter.GetComponent<Animator>().enabled = true;
            if(Input.GetKeyDown(KeyCode.Escape)) {
            mainCharacter.GetComponent<AudioSource>().enabled = true;
            backGroundAudio.GetComponent<AudioSource>().Play();
            }
        }
    }

    private void MenuToggle() {
        if(escPressed == false) {
            pauzeMenu.SetActive(false);
            resumeButton.SetActive(false);
            quitButton.SetActive(false);
        }

        if(escPressed == true) {
            pauzeMenu.SetActive(true);
            resumeButton.SetActive(true);
            quitButton.SetActive(true);
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