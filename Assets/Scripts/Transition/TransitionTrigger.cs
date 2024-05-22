using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTrigger : MonoBehaviour {
    [SerializeField] MovementScript movementScript;
    [SerializeField] Camera mainCamera;
    public Animator Crossfade;
    public int sceneBuildIndex; 
    private bool triggered = false;
    private float speed = 1.25f;
    private float timer;

    private void Update() {
        if (timer > 0){
            timer -= Time.deltaTime;
            if (timer <= 0f){
                StartCoroutine(FadeDelay());
                Crossfade.SetTrigger("Go");
            }

            if(/*een van de teleporters binnen var*/) {
                TimerOff();
            }

            if(/*een van de teleporters buiten var*/) {
                TimerOn();
            }

            if(/**/) {
                
            }
        }
    }

    private void TimerOn() {
        timer = 0.5f;
    }

    private void TimerOff() {
        timer = 0f;
    }
   
    void FixedUpdate() {
        if(triggered == true) {
            Zooming();
        }
    }

    private void Zooming() {
        mainCamera.orthographicSize = mainCamera.orthographicSize + -0.02f * speed;
        if(mainCamera.orthographicSize < 1) {
            speed = 0f;
            mainCamera.orthographicSize = mainCamera.orthographicSize;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Character"){
            triggered = true;
            movementScript.animator.SetFloat("Horizontal", 0f);
            movementScript.animator.SetFloat("Vertical", 0f);
            movementScript.animator.SetFloat("Speed", 0f);
            movementScript.enabled = false;
        } 
    }

    private IEnumerator FadeDelay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
