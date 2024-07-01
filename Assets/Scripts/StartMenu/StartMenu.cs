using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator Crossfade;
    [SerializeField] GameObject Fade;

     void Start (){
        Fade.SetActive(false);
    }

    public void Quitfunction(){
        Application.Quit();
        Debug.Log("Exit");
    }

    public void Playfunction(){

        Fade.SetActive(true);
        StartCoroutine(FadeDelay());
        Crossfade.SetTrigger("Go");  
    }

    public IEnumerator FadeDelay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
