using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer4s : MonoBehaviour
{

    private float timer = 4f;
    private bool TimerCheck = false;
    public Animator Crossfade;

    [SerializeField] TransitionTrigger transitionTrigger;

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
    }
}

    

