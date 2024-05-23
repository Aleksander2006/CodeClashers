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
    private float timerBuiten;
    private float timerBinnen;

    bool theValue = false;

    void Start() {
        if(StaticData.floatToKeep == "teleporter_1a" || StaticData.floatToKeep == "teleporter_1b" || StaticData.floatToKeep == "teleporter_1c" || StaticData.floatToKeep == "teleporter_1d" || StaticData.floatToKeep == null || StaticData.floatToKeep == "teleporter_1a_u") {
            theValue = true;
        }
    }

    private void Update() {
        if (timerBuiten > 0){
            timerBuiten -= Time.deltaTime;
            if (timerBuiten <= 0f){
                StartCoroutine(FadeDelay());
                Crossfade.SetTrigger("Go");
            }

        if(timerBinnen > 0){
            timerBinnen -= Time.deltaTime;
            if (timerBinnen <= 0f){
                StartCoroutine(FadeDelay());
                Crossfade.SetTrigger("Go");
            }
        }

        if(theValue == true && triggered == true) {
            timerBinnen = 0.01f;
            timerBuiten = 0.01f;
            Debug.Log("timer = 0");
            theValue = false;
            }  
        }
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
            Debug.Log("triggered = true");
            movementScript.animator.SetFloat("Horizontal", 0f);
            movementScript.animator.SetFloat("Vertical", 0f);
            movementScript.animator.SetFloat("Speed", 0f);
            movementScript.enabled = false;
            timerBuiten = 0.5f;
        } 
    }

    private IEnumerator FadeDelay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
