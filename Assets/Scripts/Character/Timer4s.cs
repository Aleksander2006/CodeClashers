using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer4s : MonoBehaviour
{

    private float timer = 4f;
    private bool TimerCheck = false;
    private string timerString;
    private float timerRounded;
    public Animator Crossfade;

    [SerializeField] TransitionTrigger transitionTrigger;

    [SerializeField] Animator animator;
    [SerializeField] MovementScript movementScript;

    [SerializeField] TextMeshProUGUI redTimer;

    void Start(){
        transitionTrigger.GetComponent<TransitionTrigger>();
        redTimer.enabled = false;
    }
    
    private void OnTriggerEnter2D (Collider2D other){

        if (other.tag == "Waterlayer1" || other.tag == "Waterlayer2" || other.tag == "Waterlayer3")
        {
           TimerCheck = true; 
        } 
    }
    
    private void OnTriggerExit2D (Collider2D other){
        if (other.tag == "Waterlayer1" || other.tag == "Waterlayer2" || other.tag == "Waterlayer3"){

            TimerCheck = false;
            Debug.Log(timer);  
            animator.SetBool("DrownPlayer", false);
            animator.SetFloat("Speed", 0.05f);
        }
    }

    private void Timer(){
        if (timer > 0){
            timer -= Time.deltaTime;
            Debug.Log(timer);
        }     
    }

    public IEnumerator FadeDelay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    void Update()
    {      
        if (TimerCheck == true){
            Timer();
        }

        if (TimerCheck == false){
            timer = 4;
        }

        if (timer <= 0){ 
            StartCoroutine(FadeDelay());
            Crossfade.SetTrigger("Go");
            timer = 0f;
        }

        if(timer < 1.75) {
            animator.SetBool("DrownPlayer", true);
            animator.SetFloat("Speed", 0.001f);
        }

        if(timer < 4) {
            redTimer.enabled = true;
        }

        if(timer > 3.99) {
            redTimer.enabled = false;
        }

        timerRounded = (float)Math.Round(timer, 1);
        timerString = timerRounded.ToString();
        redTimer.text = timerString;
    }
}

    

