using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer4s : MonoBehaviour
{

    private float timer = 4f;
    private bool TimerCheck = false;
    public Animator Crossfade;

    [SerializeField] TransitionTrigger transitionTrigger;

    [SerializeField] Animator animator;
    [SerializeField] MovementScript movementScript;

    void Start(){
        transitionTrigger.GetComponent<TransitionTrigger>();
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
        }

        if(timer < 1.75) {
            animator.SetBool("DrownPlayer", true);
            animator.SetFloat("Speed", 0.001f);
        }
    }
}

    

