using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFunction : MonoBehaviour
{

    public Animator Crossfade;



    void Start (){
        //Crossfade.SetBool("Start", false);
        //Crossfade.enabled = false;
    }

    public void Playfunction(){
        Debug.Log("PRESSED");

        StartCoroutine(FadeDelay());
        Crossfade.SetTrigger("Go");
        //Crossfade.SetBool("Start", true);
        //SceneManager.LoadScene(1);  
    }

    public IEnumerator FadeDelay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
