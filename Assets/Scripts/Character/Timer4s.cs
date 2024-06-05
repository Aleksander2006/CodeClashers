using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer4s : MonoBehaviour
{

    private float timer = 0f;
    
    private void OnTriggerEnter2D (Collider2D other){
        if (other.tag == "Waterlayer1" || other.tag == "Waterlayer2" || other.tag == "Waterlayer3"){
        
        

        }  
    }
    
    
        //SceneManager.LoadScene(3); //hier moet staan na 4 sec restart scene
    private void OnTriggerExit2D (Collider2D other){
        if (other.tag == "Waterlayer1" || other.tag == "Waterlayer2" || other.tag == "Waterlayer3"){

            //timer = 0;
            //hier moet staan reset timer
            
        }
    }
        void Update()
        {
           
        }

}

    

